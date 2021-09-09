using Microsoft.AspNetCore.Hosting;
using System;
using System.IO;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

namespace ADFSProxyCertRenew.CMD
{
    internal static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        private static void Main()
        {           
            Configuration configuration = Configuration.Load();

            IWebHost webserver = new WebHostBuilder().UseHttpSys().UseUrls("http://+:80/.well-known/acme-challenge/").UseStartup<WebServer.StartUp>().Build();
            webserver.Start();
            Console.WriteLine("Webserver is Running");

            

            ACMEController aCMEController = new ACMEController(configuration.AcmeServer, configuration.RegestrationMailAdress, configuration.WorkingDir);
            if (aCMEController.NeedToBeRegisterd)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ACME Client is not registerd on " + configuration.AcmeServer + " with mailadress: " + configuration.RegestrationMailAdress);
                Console.WriteLine("Task not completed.");
                Console.ResetColor();
                return;
            }
            ADFSProxyController aDFSProxyController = new ADFSProxyController();

            foreach (ACMECertificate aCMECertificate in configuration.ACMECertificates)
            {
                try
                {
                    Console.WriteLine("Process certificate: " + aCMECertificate.CommonName);
                    Console.WriteLine("Certificate valid to: " + aCMECertificate.ActualCertificateExpiresOn.ToShortDateString());
                    if (aCMECertificate.ActualCertificateExpiresOn.AddDays(-14) < DateTime.Now)
                    {
                        Console.WriteLine("Certificate renew started: " + aCMECertificate.CommonName);
                        string CertificatePath = aCMEController.CreateCertificate(aCMECertificate);
                        Console.WriteLine("Import certificate in local store: " + aCMECertificate.CommonName);
                        X509Certificate2 certificate = CertificateManagement.InstallCertificate(CertificatePath, aCMECertificate.PFXPassword);
                        aCMECertificate.ActualCertificateThumbprint = certificate.Thumbprint;
                        aCMECertificate.ActualCertificateExpiresOn = certificate.NotAfter;
                        foreach (Guid wapid in aCMECertificate.ADFSWebApplicationProxyBindings)
                        {
                            Console.WriteLine("Set ExternalCertificateThumbprint on " + wapid.ToString() + " to " + aCMECertificate.ActualCertificateThumbprint);
                            aDFSProxyController.SetWebApplicationProxyApplicationExternalThumbprint(wapid, aCMECertificate.ActualCertificateThumbprint);
                        }
                        if (aCMECertificate.BindToWebApplicationProxySslCertificate)
                        {
                            Console.WriteLine("Set WebApplicationProxySslCertificate" + " to " + aCMECertificate.ActualCertificateThumbprint);
                            aDFSProxyController.SetWebApplicationProxySslCertificate(aCMECertificate.ActualCertificateThumbprint);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error in certificate process: " + aCMECertificate.CommonName);
                    writeException(ex);
                    Console.ResetColor();
                }
            }

            configuration.Save();
        }

        private static void writeException(Exception ex)
        {
            Console.WriteLine("-> " + ex.Message);
            if(ex is ReflectionTypeLoadException)
            {
                foreach(Exception e in ((ReflectionTypeLoadException)ex).LoaderExceptions)
                {
                    Console.WriteLine("--> " + e.Message);
                }
            }
            if (ex.InnerException != null)
            {
                writeException(ex.InnerException);
            }
            Console.WriteLine(ex.StackTrace);
        }
    }
}
