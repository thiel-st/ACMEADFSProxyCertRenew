using Microsoft.Management.Infrastructure;
using System;

namespace ADFSProxyCertRenew.AdfsProxy
{
    public class WebApplicationProxyApplication
    {
        public string ADFSRelyingPartyID { get; set; }
        public string ADFSRelyingPartyName { get; set; }
        public BackendServerAuthenticationMode BackendServerAuthenticationMode { get; set; }
        public string BackendServerAuthenticationSPN { get; set; }
        public BackendServerCertificateValidation BackendServerCertificateValidation { get; set; }
        public string BackendServerUrl { get; set; }
        public ClientCertificateAuthenticationBindingMode ClientCertificateAuthenticationBindingMode { get; set; }
        public string ClientCertificatePreauthenticationThumbprint { get; set; }
        public bool DisableHttpOnlyCookieProtection { get; set; }
        public bool DisableTranslateUrlInRequestHeaders { get; set; }
        public bool DisableTranslateUrlInResponseHeaders { get; set; }
        public string ExternalCertificateThumbprint { get; set; }
        public string ExternalPreauthentication { get; set; }
        public string ExternalUrl { get; set; }
        public Guid ID { get; set; }
        public UInt32 InactiveTransactionsTimeoutSec { get; set; }
        public string Name { get; set; }
        public bool UseOAuthAuthentication { get; set; }

        public WebApplicationProxyApplication()
        { }
        public WebApplicationProxyApplication(CimInstance cimInstance)
        {
            foreach (CimProperty c in cimInstance.CimInstanceProperties)
            {
                switch (c.Name)
                {
                    case "ADFSRelyingPartyID":
                        this.ADFSRelyingPartyID = (string)c.Value;
                        break;
                    case "ADFSRelyingPartyName":
                        this.ADFSRelyingPartyName = (string)c.Value;
                        break;
                    case "BackendServerAuthenticationMode":
                        switch (c.Value.ToString())
                        {
                            case "NoAuthentication":
                                this.BackendServerAuthenticationMode = BackendServerAuthenticationMode.NoAuthentication;
                                break;
                            case "IntegratedWindowsAuthentication":
                                this.BackendServerAuthenticationMode = BackendServerAuthenticationMode.IntegratedWindowsAuthentication;
                                break;
                        }
                        break;
                    case "BackendServerAuthenticationSPN":
                        this.BackendServerAuthenticationSPN = (string)c.Value;
                        break;
                    case "BackendServerCertificateValidation":
                        switch (c.Value.ToString())
                        {
                            case "None":
                                this.BackendServerCertificateValidation = BackendServerCertificateValidation.None;
                                break;
                            case "ValidateCertificate":
                                this.BackendServerCertificateValidation = BackendServerCertificateValidation.ValidateCertificate;
                                break;
                        }
                        break;
                    case "BackendServerUrl":
                        this.BackendServerUrl = (string)c.Value;
                        break;
                    case "ClientCertificateAuthenticationBindingMode":
                        switch (c.Value.ToString())
                        {
                            case "None":
                                this.ClientCertificateAuthenticationBindingMode = ClientCertificateAuthenticationBindingMode.None;
                                break;
                            case "ValidateCertificate":
                                this.ClientCertificateAuthenticationBindingMode = ClientCertificateAuthenticationBindingMode.ValidateCertificate;
                                break;
                        }
                        break;
                    case "ClientCertificatePreauthenticationThumbprint":
                        this.ClientCertificatePreauthenticationThumbprint = (string)c.Value;
                        break;
                    case "DisableHttpOnlyCookieProtection":
                        this.DisableHttpOnlyCookieProtection = (bool)c.Value;
                        break;
                    case "DisableTranslateUrlInRequestHeaders":
                        this.DisableTranslateUrlInRequestHeaders = (bool)c.Value;
                        break;
                    case "DisableTranslateUrlInResponseHeaders":
                        this.DisableTranslateUrlInResponseHeaders = (bool)c.Value;
                        break;
                    case "ExternalCertificateThumbprint":
                        this.ExternalCertificateThumbprint = (string)c.Value;
                        break;
                    case "ExternalPreauthentication":
                        this.ExternalPreauthentication = (string)c.Value;
                        break;
                    case "ExternalUrl":
                        this.ExternalUrl = (string)c.Value;
                        break;
                    case "ID":
                        this.ID = new Guid((string)c.Value);
                        break;
                    case "InactiveTransactionsTimeoutSec":
                        this.InactiveTransactionsTimeoutSec = (UInt32)c.Value;
                        break;
                    case "Name":
                        this.Name = (string)c.Value;
                        break;
                    case "UseOAuthAuthentication":
                        this.UseOAuthAuthentication = (bool)c.Value;
                        break;
                }
            }
        }
    }

    public enum ClientCertificateAuthenticationBindingMode
    {
        None = 0,
        ValidateCertificate = 1
    }
    public enum BackendServerCertificateValidation
    {
        None = 0,
        ValidateCertificate = 1
    }
    public enum BackendServerAuthenticationMode
    {
        NoAuthentication = 0,
        IntegratedWindowsAuthentication = 1
    }
}
