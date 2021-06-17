using ADFSProxyCertRenew.AdfsProxy;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Management.Automation;

namespace ADFSProxyCertRenew
{
    public class ADFSProxyController
    {
        public List<WebApplicationProxyApplication> GetWebApplicationProxyApplications()
        {
            List<WebApplicationProxyApplication> result = new List<WebApplicationProxyApplication>();
            using (PowerShell PowerShellInstance = PowerShell.Create())
            {
                PowerShellInstance.AddScript("Get-WebApplicationProxyApplication");
                Collection<PSObject> psoutput = PowerShellInstance.Invoke();
                foreach (PSObject outputItem in psoutput)
                {
                    if (outputItem != null)
                    {
                        Console.WriteLine(outputItem.BaseObject.GetType().FullName);
                        Microsoft.Management.Infrastructure.CimInstance cimInstance = outputItem.BaseObject as Microsoft.Management.Infrastructure.CimInstance;
                        if (cimInstance != null)
                        {
                            WebApplicationProxyApplication wapa = new WebApplicationProxyApplication(cimInstance);
                            result.Add(wapa);
                        }
                    }
                }
            }
            return result;
        }

        public bool SetWebApplicationProxyApplicationExternalThumbprint(Guid wapid, string actualCertificateThumbprint)
        {
            bool result = false;
            using (PowerShell PowerShellInstance = PowerShell.Create())
            {
                PowerShellInstance.AddScript("Set-WebApplicationProxyApplication -ID " + wapid.ToString() + " -ExternalCertificateThumbprint " + actualCertificateThumbprint);
                Collection <PSObject> psoutput = PowerShellInstance.Invoke();
                result = true;
            }
            return result;
        }

        public bool SetWebApplicationProxySslCertificate(string actualCertificateThumbprint)
        {
            bool result = false;
            using (PowerShell PowerShellInstance = PowerShell.Create())
            {
                PowerShellInstance.AddScript("set-WebApplicationProxySslCertificate -Thumbprint " + actualCertificateThumbprint);
                Collection<PSObject> psoutput = PowerShellInstance.Invoke();
                result = true;
            }
            return result;
        }
    }
}
