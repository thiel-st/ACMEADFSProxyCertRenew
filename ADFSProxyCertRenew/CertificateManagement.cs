using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ADFSProxyCertRenew
{
    public class CertificateManagement
    {
        public static X509Certificate2 InstallCertificate(string CertificatesPath,string PFXPassword)
        {
            X509Store store;

            string pfxFilename = Path.Combine(CertificatesPath, "all.pfx");
            try
            {
                store = new X509Store(StoreName.My, StoreLocation.LocalMachine);
                store.Open(OpenFlags.OpenExistingOnly | OpenFlags.ReadWrite);
            }
            catch (CryptographicException)
            {
                store = new X509Store(StoreName.My, StoreLocation.LocalMachine);
                store.Open(OpenFlags.OpenExistingOnly | OpenFlags.ReadWrite);
            }

            Console.WriteLine($" Opened Certificate Store \"{store.Name}\"");

            X509Certificate2 certificate = null;
            try
            {
                certificate = new X509Certificate2(pfxFilename, PFXPassword, X509KeyStorageFlags.MachineKeySet | X509KeyStorageFlags.PersistKeySet | X509KeyStorageFlags.Exportable);

                //certificate.FriendlyName = $"{binding.Host} {DateTime.Now.ToString(Properties.Settings.Default.FileDateFormat)}";

                Console.WriteLine($" Adding Certificate to Store");
                store.Add(certificate);

                Console.WriteLine($" Closing Certificate Store");
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error saving certificate: {ex.Message.ToString()}");
                Console.ResetColor();
            }
            store.Close();

            return certificate;
        }
    }
}
