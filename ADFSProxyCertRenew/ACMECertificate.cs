using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ADFSProxyCertRenew
{
    [DataContract]
    public class ACMECertificate
    {
        [DataMember]
        public string CommonName { get; set; }
        [DataMember]
        public string PFXPassword { get; set; }
        [DataMember]
        public List<string> AlternativeNames { get; set; } = new List<string>();
        [DataMember]
        public string Country { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string GivenName { get; set; }
        [DataMember]
        public string Initials { get; set; }
        [DataMember]
        public string Locality { get; set; }
        [DataMember]
        public string Organization { get; set; }
        [DataMember]
        public string OrganizationUnit { get; set; }
        [DataMember]
        public string StateOrProvince { get; set; }
        [DataMember]
        public string Surname { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public List<Guid> ADFSWebApplicationProxyBindings { get; set; } = new List<Guid>();
        [DataMember]
        public string ActualCertificateThumbprint { get; set; }
        [DataMember]
        public DateTime ActualCertificateExpiresOn { get; set; } = DateTime.Now;
        [DataMember]
        public bool BindToWebApplicationProxySslCertificate { get; set; } = false;
        [DataMember]
        public bool AutoRenew { get; set; } = false;

        public override string ToString()
        {
            return this.CommonName;
        }
    }
}