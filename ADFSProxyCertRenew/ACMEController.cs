using ACMESharp;
using ACMESharp.Authorizations;
using ACMESharp.Crypto.JOSE;
using ACMESharp.HTTP;
using ACMESharp.Protocol;
using ACMESharp.Protocol.Resources;
using ADFSProxyCertRenew.Certificate;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ADFSProxyCertRenew
{
    public class ACMEController
    {
        private readonly Uri BaseURI = new Uri("https://acme-staging.api.letsencrypt.org/");
        private string ACMESregistrationPath { get; set; }
        private string SignerPath { get; set; }
        private string RegistrationEMailAdress { get; set; }
        private string WorkingPath { get; set; }
        private string CertificatePath { get; set; }

        // Neue ACME Clients
        private AcmeProtocolClient _acme { get; set; }
        private HttpClient _http { get; set; }
        public bool NeedToBeRegisterd { get; private set; }
        public string ACMERegistrationPath { get; set; }
        private IJwsTool accountSigner { get; set; }

        private static readonly Dictionary<string, Http01ChallengeValidationDetails> _Challenges = new Dictionary<string, Http01ChallengeValidationDetails>();
        private static readonly object _challengesLock = new object();
        public static Dictionary<string, Http01ChallengeValidationDetails> Challenges
        {
            get
            {
                lock (_challengesLock)
                {
                    return _Challenges;
                }
            }
        }
        private void CreateWorkingDirs()
        {
            if (!Directory.Exists(this.WorkingPath))
            {
                throw new Exception("Working Directory don't exist.");
            }

            string AcmeServerDirectoryName = this.BaseURI.DnsSafeHost.Replace('.', '_');
            if (!Directory.Exists(Path.Combine(this.WorkingPath, AcmeServerDirectoryName)))
            {
                Directory.CreateDirectory(Path.Combine(this.WorkingPath, AcmeServerDirectoryName));
            }

            string EMailDirectoryName = this.RegistrationEMailAdress.Replace('.', '_').Replace('@', '_');
            if (!Directory.Exists(Path.Combine(this.WorkingPath, AcmeServerDirectoryName, EMailDirectoryName)))
            {
                Directory.CreateDirectory(Path.Combine(this.WorkingPath, AcmeServerDirectoryName, EMailDirectoryName));
            }

            this.CertificatePath = Path.Combine(this.WorkingPath, AcmeServerDirectoryName, EMailDirectoryName, "Certificates");
            if (!Directory.Exists(this.CertificatePath))
            {
                Directory.CreateDirectory(this.CertificatePath);
            }
            this.ACMERegistrationPath = Path.Combine(this.WorkingPath, AcmeServerDirectoryName, EMailDirectoryName, "AcmeV2");
        }
        public ACMEController(string baseURI, string registrationEMailAdress) : this(baseURI, registrationEMailAdress, Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
        { }
        public ACMEController(string baseURI, string registrationEMailAdress, string workingPath)
        {
            this.WorkingPath = workingPath;
            this.BaseURI = new Uri(baseURI);
            this.RegistrationEMailAdress = registrationEMailAdress;

            this.CreateWorkingDirs();
            var task = Task.Run(async () => { await this.Init(); });
            task.Wait();
        }

        public async Task Init()
        {
            Console.WriteLine("################################################################################");
            Console.WriteLine("## ACCOUNT");
            Console.WriteLine("################################################################################");
            Console.WriteLine();

            if (!Directory.Exists(this.ACMERegistrationPath))
            {
                Console.WriteLine($"Creating State Persistence Path [{this.ACMERegistrationPath}]");
                Directory.CreateDirectory(this.ACMERegistrationPath);
                Console.WriteLine();
            }

            ServiceDirectory acmeDir = default;
            if (LoadStateInto(ref acmeDir, failThrow: false,
                    "00-ServiceDirectory"))
            {
                Console.WriteLine("Loaded existing Service Directory");
                Console.WriteLine();
            }

            AccountDetails account = default;
            if (LoadStateInto(ref account, failThrow: false,
                    "10-AccountDetails"))
            {
                Console.WriteLine($"Loaded Account Details for KID:");
                Console.WriteLine($"  Account KID....: {account.Kid}");
                Console.WriteLine();
            }

            accountSigner = default;
            ACMEAccountKey accountKey = default;
            string accountKeyHash = default;
            if (LoadStateInto(ref accountKey, failThrow: false,
                    "15-AccountKey"))
            {
                accountSigner = accountKey.GenerateTool();
                accountKeyHash = ComputeHash(accountSigner.Export());
                Console.WriteLine($"Loaded EXISTING Account Key:");
                Console.WriteLine($"  Key Type...........: {accountKey.KeyType}");
                Console.WriteLine($"  Key Export Hash....: {accountKeyHash}");
                Console.WriteLine();
            }

            _http = new HttpClient { BaseAddress = this.BaseURI, };
            _acme = new AcmeProtocolClient(_http, acmeDir, account, accountSigner);
            if (acmeDir == null)
            {
                Console.WriteLine("Refreshing Service Directory");
                acmeDir = await _acme.GetDirectoryAsync();
                _acme.Directory = acmeDir;
                SaveStateFrom(acmeDir, "00-ServiceDirectory");
                Console.WriteLine();
            }

            await _acme.GetNonceAsync();

            if (account == null || accountSigner == null)
            {
                this.NeedToBeRegisterd = true;
            }
            else
            {
                this.NeedToBeRegisterd = false;
                // Dump out Account Details
                var contacts = account.Payload.Contact;
                var contactsJoined = contacts == null ? string.Empty : string.Join(",", contacts);
                Console.WriteLine($"Account Details:");
                Console.WriteLine($"  Id..........: {account?.Payload?.Id}");
                Console.WriteLine($"  Kid.........: {account?.Kid}");
                Console.WriteLine($"  Status......: {account?.Payload?.Status}");
                Console.WriteLine($"  Contacts....: {contactsJoined}");
                // Dump out Account Key
                accountKeyHash = ComputeHash(accountSigner.Export());
                Console.WriteLine($"Account Key:");
                Console.WriteLine($"  JWS Algorithm......: {_acme.Signer.JwsAlg}");
                Console.WriteLine($"  Impl Class Type....: {_acme.Signer.GetType().Name}");
                Console.WriteLine($"  Key Export Hash....: {accountKeyHash}");
                Console.WriteLine();
            }
        }
        public void RegisterACMEClient()
        {
            var task = Task.Run(async () => { await this.RegisterACMEClientAsync(); });
            task.Wait();
        }
        public async Task RegisterACMEClientAsync()
        {
            List<string> emaillist = new List<string>() { "mailto:" + this.RegistrationEMailAdress };
            AccountDetails account = await _acme.CreateAccountAsync(emaillist, true);
            IJwsTool accountSigner = _acme.Signer;
            ACMEAccountKey accountKey = new ACMEAccountKey
            {
                KeyType = accountSigner.JwsAlg,
                KeyExport = accountSigner.Export(),
            };
            SaveStateFrom(account, "10-AccountDetails");
            SaveStateFrom(accountKey, "15-AccountKey");
            _acme.Account = account;

            // Dump out Account Details
            var contacts = account.Payload.Contact;
            var contactsJoined = contacts == null ? string.Empty : string.Join(",", contacts);
            Console.WriteLine($"Account Details:");
            Console.WriteLine($"  Id..........: {account?.Payload?.Id}");
            Console.WriteLine($"  Kid.........: {account?.Kid}");
            Console.WriteLine($"  Status......: {account?.Payload?.Status}");
            Console.WriteLine($"  Contacts....: {contactsJoined}");
            // Dump out Account Key
            string accountKeyHash = ComputeHash(accountSigner.Export());
            Console.WriteLine($"Account Key:");
            Console.WriteLine($"  JWS Algorithm......: {_acme.Signer.JwsAlg}");
            Console.WriteLine($"  Impl Class Type....: {_acme.Signer.GetType().Name}");
            Console.WriteLine($"  Key Export Hash....: {accountKeyHash}");
            Console.WriteLine();
        }
        public string CreateCertificate(ACMECertificate aCMECertificateConfiguration)
        {
            var task = Task.Run(async () => { await this.CreateCertificateAsync(aCMECertificateConfiguration); });
            task.Wait();
            string certificatePath = Path.Combine(this.CertificatePath, aCMECertificateConfiguration.CommonName.Replace('.', '_'));
            certificatePath = Path.Combine(certificatePath, DateTime.Now.ToString("yyyy-MM-dd"));
            return certificatePath;
        }
        public async Task<string> CreateCertificateAsync(ACMECertificate aCMECertificateConfiguration)
        {
            if (aCMECertificateConfiguration.AlternativeNames != null && aCMECertificateConfiguration.AlternativeNames.Count > 99)
            {
                throw new Exception("To Manny Domains for one certificate. Max count is 99");
            }

            string certificatePath = Path.Combine(this.CertificatePath, aCMECertificateConfiguration.CommonName.Replace('.', '_'));

            if (!Directory.Exists(certificatePath))
            {
                Directory.CreateDirectory(certificatePath);
            }

            certificatePath = Path.Combine(certificatePath, DateTime.Now.ToString("yyyy-MM-dd"));

            if (!Directory.Exists(certificatePath))
            {
                Directory.CreateDirectory(certificatePath);
            }

            List<string> DomainList = new List<string>();
            DomainList.Add(aCMECertificateConfiguration.CommonName);
            if (aCMECertificateConfiguration.AlternativeNames != null)
            {
                foreach (string domain in aCMECertificateConfiguration.AlternativeNames)
                {
                    DomainList.Add(domain);
                }
            }

            this.AuthorizeDomains(DomainList, aCMECertificateConfiguration, certificatePath);
            return certificatePath;
        }

        private void AuthorizeDomains(IEnumerable<string> Dns, ACMECertificate aCMECertificateConfiguration, string certificatePath)
        {
            Console.WriteLine("################################################################################");
            Console.WriteLine("## ORDER");
            Console.WriteLine("################################################################################");
            Console.WriteLine();

            var dnsNames = Dns;
            var certName = string.Join(",", dnsNames.Distinct()).Replace("%", "").ToLower();
            var certNameHash = ComputeHash(certName);
            var orderId = certNameHash;

            OrderDetails order = default;
            //LoadStateInto(ref order, failThrow: false,
            //        "50-Orders/{0}/0-Order", orderId);

            if (order == null)
            {
                Console.WriteLine("Creating NEW Order");
                order = _acme.CreateOrderAsync(dnsNames).Result;
                SaveStateFrom(order, "50-Orders/{0}/0-Order", orderId);
            }

            // Dump out Order Details
            Console.WriteLine($"Order Details:");
            Console.WriteLine($"  Order URL......: {order.OrderUrl}");
            Console.WriteLine($"  Expires........: {order.Payload.Expires}");
            Console.WriteLine($"  Status.........: {order.Payload.Status}");
            Console.WriteLine($@"  Identifiers....: {string.Join(",",
                    order.Payload.Identifiers.Select(x => $"{x.Type}:{x.Value}"))}");
            Console.WriteLine();

            if (order.Payload.Status == "invalid")
                throw new Exception("Order is already marked as INVALID");
            if (order.Payload.Status != "ready")
            {

                Console.WriteLine("Refreshing EXISTING Order");
                order = _acme.GetOrderDetailsAsync(order.OrderUrl, existing: order).Result;
                SaveStateFrom(order, "50-Orders/{0}/0-Order", orderId);

                if (order.Payload.Status == "invalid")
                    throw new Exception("Order is already marked as INVALID");

                if (order.Payload.Status != "pending")
                {
                    throw new Exception("Status from Order is Wrong: " + order.Payload.Status);
                }

                var authzStatusCounts = new Dictionary<string, int>
                {
                    ["valid"] = 0,
                    ["invalid"] = 0,
                    ["pending"] = 0,
                    ["unknown"] = 0,
                };

                void AddStatusCount(string status, int add)
                {
                    if (!authzStatusCounts.ContainsKey(status))
                        status = "unknown";
                    authzStatusCounts[status] += add;
                }

                Console.WriteLine("== Authorizations ==============================================================");
                Console.WriteLine();

                foreach (var authzUrl in order.Payload.Authorizations)
                {
                    var authzId = ComputeHash(authzUrl);
                    Authorization authz = default;
                    LoadStateInto(ref authz, failThrow: false,
                            "50-Orders/{0}/2-Authz_{1}", orderId, authzId);
                    if (authz == null)
                    {
                        Console.WriteLine("Getting Authorization Details...");
                        authz = _acme.GetAuthorizationDetailsAsync(authzUrl).Result;
                        SaveStateFrom(authz, "50-Orders/{0}/2-Authz_{1}", orderId, authzId);
                    }

                    Console.WriteLine($"Identifier: [{authz.Identifier.Value}]");
                    Console.WriteLine($"  Status.............: {authz.Status}");
                    Console.WriteLine($"  Expires............: {authz.Expires}");
                    Console.WriteLine($"  Is Wildcard........: {authz.Wildcard}");
                    Console.WriteLine($"  Challenge Count....: {authz.Challenges.Length}");
                    Console.WriteLine();

                    AddStatusCount(authz.Status, 1);

                    Console.WriteLine("-- Challenges ------------------------------------------------------------------");
                    int chlngCount = 0;
                    foreach (var chlng in authz.Challenges.Where(x => x.Type == "http-01"))
                    {
                        Authorization authzUpdated = null;
                        Challenge chlngUpdated = chlng;
                        //if (RefreshChallenges)
                        //{
                        //    Console.WriteLine("  Refreshing Challenge...");
                        //    chlngUpdated = await _acme.GetChallengeDetailsAsync(chlng.Url);
                        //}
                        var cd = AuthorizationDecoder.DecodeChallengeValidation(authz, chlng.Type, accountSigner);
                        switch (chlng.Type)
                        {
                            case Dns01ChallengeValidationDetails.Dns01ChallengeType:
                                Console.WriteLine("DNS Challenge Skip");
                                break;
                            case Http01ChallengeValidationDetails.Http01ChallengeType:
                                var httpCd = (Http01ChallengeValidationDetails)cd;
                                Console.WriteLine($"  Challenge of Type: [{httpCd.ChallengeType}]");
                                Console.WriteLine($"    To handle this Challenge, create a file that will respond to an HTTP request with these details:");
                                Console.WriteLine($"        HTTP Full URL.................: {httpCd.HttpResourceUrl}");
                                Console.WriteLine($"        HTTP Resource Path............: {httpCd.HttpResourcePath}");
                                Console.WriteLine($"        HTTP Resource Value...........: {httpCd.HttpResourceValue}");
                                Console.WriteLine($"        HTTP Resource Content-Type....: {httpCd.HttpResourceContentType}");

                                string httpfilename = httpCd.HttpResourcePath.Substring(".well-known/acme-challenge/".Length);
                                ACMEController.Challenges.Add(httpfilename, httpCd);
                                Console.WriteLine("HTTP Challenge File: " + httpCd.HttpResourceUrl);
                                break;
                            default:
                                Console.WriteLine($"  Challenge of Type: {cd.ChallengeType}");
                                Console.WriteLine($"  This Challenge type is unknown, but here are the details:");
                                Console.WriteLine(JsonConvert.SerializeObject(cd));
                                break;
                        }

                        do
                        {
                            Console.WriteLine("  chlng.Status: " + chlngUpdated.Status);
                            Console.WriteLine("  authz.Status: " + authz.Status);
                            Console.WriteLine("  Answering Challenge...");
                            if (authz.Status == "pending")
                            {
                                authzUpdated = _acme.GetAuthorizationDetailsAsync(authzUrl).Result;
                            }
                            if (chlngUpdated.Status == "pending" && chlngUpdated.Type == "http-01" && authz.Status == "pending")
                            {
                                chlngUpdated = _acme.AnswerChallengeAsync(chlng.Url).Result;
                            }


                            if (chlngUpdated != null)
                            {
                                SaveStateFrom(chlngUpdated, "50-Orders/{0}/4-AuthzChlng_{1}_{2}",
                                        orderId, authzId, chlngUpdated.Type);
                            }
                            if (authzUpdated != null)
                            {
                                if (authzUpdated.Status != authz.Status)
                                {
                                    AddStatusCount(authz.Status, -1);
                                    AddStatusCount(authzUpdated.Status, 1);
                                }
                                authz = authzUpdated;
                                SaveStateFrom(authz, "50-Orders/{0}/2-Authz_{1}", orderId, authzId);
                                authzUpdated = null;
                            }
                        } while (authz.Status != "valid");
                        ++chlngCount;
                    }
                }
                if (authzStatusCounts["valid"] < order.Payload.Authorizations.Length)
                {
                    int validStatusCount = 0;

                    Console.WriteLine("Waiting for Authorizations to be Validated...");
                    var waitUntil = DateTime.Now.AddSeconds(300);
                    foreach (var authzUrl_a in order.Payload.Authorizations)
                    {
                        var authz_a = _acme.GetAuthorizationDetailsAsync(authzUrl_a).Result;
                        Console.WriteLine($"  Identifier: {authz_a.Identifier.Type}:{authz_a.Identifier.Value}:");
                        while (authz_a.Status != "valid"
                                && DateTime.Now < waitUntil)
                        {
                            Thread.Sleep(1 * 1000);
                            authz_a = _acme.GetAuthorizationDetailsAsync(authzUrl_a).Result;
                        }
                        Console.WriteLine($"    Status: {authz_a.Status}");
                        if (authz_a.Status == "valid")
                            ++validStatusCount;
                    }
                    Console.WriteLine();

                    if (validStatusCount < order.Payload.Authorizations.Length)
                        throw new Exception("Cannot finalize Order until all Authorizations are valid");
                }
            }
            PkiKeyPair keyPair = null;
            PkiCertificateSigningRequest csr = null;

            string certKeys = null;
            byte[] certCsr = null;

            if (LoadStateInto(ref certKeys, failThrow: false,
                    "50-Orders/{0}/6-CertKey", orderId))
                Console.WriteLine("Loaded existing Certificate key pair");
            if (LoadStateInto(ref certCsr, failThrow: false,
                    "50-Orders/{0}/7-CsrDer", orderId))
                Console.WriteLine("Loaded existing CSR");

            if (certKeys == null || certCsr == null)
            {
                Console.WriteLine("Generating Certificate key pair and CSR...");
                keyPair = PkiKeyPair.GenerateRsaKeyPair(2048);

            }

            csr = GenerateCsr(Dns, keyPair);
            certKeys = Save(keyPair);
            certCsr = csr.ExportSigningRequest(PkiEncodingFormat.Der);

            SaveStateFrom(certKeys, "50-Orders/{0}/6-CertKey", orderId);
            SaveStateFrom(certCsr, "50-Orders/{0}/7-CsrDer", orderId);

            Console.WriteLine("Finalizing Order...");
            order = _acme.FinalizeOrderAsync(order.Payload.Finalize, certCsr).Result;
            SaveStateFrom(order, "50-Orders/{0}/0-Order", orderId);


            //// Request Zertificate
            if (order.Payload.Status == "valid")
            {
                Console.WriteLine("Order is VALID");


                if (string.IsNullOrEmpty(order.Payload.Certificate))
                {

                    Console.WriteLine("Waiting for Certificate to become available");
                    var waitUntil = DateTime.Now.AddSeconds(300);
                    while (DateTime.Now < waitUntil)
                    {
                        Console.WriteLine("    Waiting... for Certificate");
                        Thread.Sleep(10 * 1000);
                        order = _acme.GetOrderDetailsAsync(order.OrderUrl, existing: order).Result;


                        SaveStateFrom(order, "50-Orders/{0}/0-Order", orderId);

                        if (!string.IsNullOrEmpty(order.Payload.Certificate))
                            break;
                    }
                }


                Console.WriteLine("Fetching Certificate...");
                var certResp = _http.GetAsync(order.Payload.Certificate).Result;
                certResp.EnsureSuccessStatusCode();
                using (var ras = certResp.Content.ReadAsStreamAsync().Result)
                {
                    SaveRaw(ras, "50-Orders/{0}/8-CertChainPem", orderId);
                }



                Console.WriteLine("Exporting Certificate as PFX (PKCS12)...");

                PkiKey privateKey = null;
                var pfxPassword = aCMECertificateConfiguration.PFXPassword;
                if (pfxPassword != null)
                {
                    Console.WriteLine("...including private key in export");
                    string certKeys1 = default;
                    LoadStateInto(ref certKeys1, failThrow: true,
                        "50-Orders/{0}/6-CertKey", orderId);
                    var keyPair2 = this.Load(certKeys1);
                    privateKey = keyPair2.PrivateKey;
                }

                using (var cert = new X509Certificate2(LoadRaw<byte[]>(true, "50-Orders/{0}/8-CertChainPem", orderId)))
                {
                    var pkiCert = PkiCertificate.From(cert);
                    var pfx = pkiCert.Export(PkiArchiveFormat.Pkcs12,
                        privateKey: privateKey,
                        password: pfxPassword?.ToCharArray());

                    File.WriteAllBytes(Path.Combine(certificatePath, "all.pfx"), pfx);
                }

            }
            else
            {
                throw new Exception($"Order is in unexpected state [{order.Payload.Status}];"
                        + $" expected pending");
            }
        }

        //private void RequestCertificates(ACMECertificate aCMECertificateConfiguration, string certificatePath)
        //{
        //    CsrDetails csrDetails = new CsrDetails()
        //    {
        //        CommonName = aCMECertificateConfiguration.CommonName,
        //        Country = aCMECertificateConfiguration.Country,
        //        Description = aCMECertificateConfiguration.Description,
        //        Email = aCMECertificateConfiguration.Email,
        //        GivenName = aCMECertificateConfiguration.GivenName,
        //        Initials = aCMECertificateConfiguration.Initials,
        //        Locality = aCMECertificateConfiguration.Locality,
        //        Organization = aCMECertificateConfiguration.Organization,
        //        OrganizationUnit = aCMECertificateConfiguration.OrganizationUnit,
        //        StateOrProvince = aCMECertificateConfiguration.StateOrProvince,
        //        Surname = aCMECertificateConfiguration.Surname,
        //        Title = aCMECertificateConfiguration.Title,
        //    };
        //}


        // Helper
        private T LoadRaw<T>(bool failThrow, string nameFormat, params object[] nameArgs)
        {
            var name = string.Format(nameFormat, nameArgs);
            var fullPath = Path.Combine(this.ACMERegistrationPath, name);
            if (!File.Exists(fullPath))
                if (failThrow)
                    throw new Exception($"Failed to read object from non-existent path [{fullPath}]");
                else
                    return default;

            if (typeof(T) == typeof(string))
                return (T)(object)File.ReadAllText(fullPath);
            else if (typeof(T) == typeof(byte[]))
                return (T)(object)File.ReadAllBytes(fullPath);
            else if (typeof(T) == typeof(Stream) || typeof(T) == typeof(FileStream))
                return (T)(object)new FileStream(fullPath, FileMode.Open);
            else
                throw new ArgumentException("Unsupported return type; must be one of:  string, byte[], Stream",
                        nameof(T));
        }
        private PkiKeyPair Load(string b64)
        {
            using (var ms = new MemoryStream(Convert.FromBase64String(b64)))
            {
                return PkiKeyPair.Load(ms);
            }
        }
        private bool LoadStateInto<T>(ref T value, bool failThrow, string nameFormat, params object[] nameArgs)
        {
            var name = string.Format(nameFormat, nameArgs);
            var fullPath = Path.Combine(this.ACMERegistrationPath, name);
            if (!File.Exists(fullPath))
                if (failThrow)
                    throw new Exception($"Failed to read object from non-existent path [{fullPath}]");
                else
                    return false;

            var ser = File.ReadAllText(fullPath);
            value = JsonConvert.DeserializeObject<T>(ser);
            return true;
        }

        private bool SaveStateFrom<T>(T value, string nameFormat, params object[] nameArgs)
        {
            var name = string.Format(nameFormat, nameArgs);
            var fullPath = Path.Combine(this.ACMERegistrationPath, name);
            var fullDir = Path.GetDirectoryName(fullPath);
            if (!Directory.Exists(fullDir))
                Directory.CreateDirectory(fullDir);

            var ser = JsonConvert.SerializeObject(value, Formatting.Indented);
            File.WriteAllText(fullPath, ser);
            return true;
        }
        private string ComputeHash(string value)
        {
            using (var sha = SHA256.Create())
            {
                var hash = sha.ComputeHash(Encoding.UTF8.GetBytes(value));
                return BitConverter.ToString(hash).Replace("-", "");
            }
        }
        private PkiCertificateSigningRequest GenerateCsr(IEnumerable<string> dnsNames,
            PkiKeyPair keyPair)
        {
            var firstDns = dnsNames.First();
            var csr = new PkiCertificateSigningRequest($"CN={firstDns}", keyPair,
                PkiHashAlgorithm.Sha256);

            csr.CertificateExtensions.Add(
                PkiCertificateExtension.CreateDnsSubjectAlternativeNames(dnsNames));

            return csr;
        }
        private string Save(PkiKeyPair keyPair)
        {
            using (var ms = new MemoryStream())
            {
                keyPair.Save(ms);
                return Convert.ToBase64String(ms.ToArray());
            }
        }
        private bool SaveRaw<T>(T value, string nameFormat, params object[] nameArgs)
        {
            var name = string.Format(nameFormat, nameArgs);
            var fullPath = Path.Combine(this.ACMERegistrationPath, name);
            var fullDir = Path.GetDirectoryName(fullPath);
            if (!Directory.Exists(fullDir))
                Directory.CreateDirectory(fullDir);

            switch (value)
            {
                case string s:
                    File.WriteAllText(fullPath, s);
                    break;
                case byte[] b:
                    File.WriteAllBytes(fullPath, b);
                    break;
                case Stream m:
                    using (var fs = new FileStream(fullPath, FileMode.Create))
                        m.CopyTo(fs);
                    break;
                default:
                    throw new ArgumentException("Unsupported value type; must be one of:  string, byte[], Stream",
                            nameof(value));
            }

            return true;
        }
    }
}
