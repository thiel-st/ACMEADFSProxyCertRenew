using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace ADFSProxyCertRenew
{
    [DataContract]
    public class Configuration
    {
        private static readonly string ConfigurationPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "configuration.json");
        [DataMember]
        public List<ACMECertificate> ACMECertificates { get; set; } = new List<ACMECertificate>();
        [DataMember]
        public string RegestrationMailAdress { get; set; }
        [DataMember]
        public string AcmeServer { get; set; }
        [DataMember]
        public string WorkingDir { get; set; } = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));

        public void Save()
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Configuration));
            using (FileStream ms = new FileStream(Configuration.ConfigurationPath, FileMode.Create))
            {
                serializer.WriteObject(ms, this);
                ms.Flush();
                ms.Close();
            }
        }
        public static Configuration Load()
        {
            Configuration result = null;
            if (File.Exists(Configuration.ConfigurationPath))
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Configuration));
                using (FileStream ms = new FileStream(Configuration.ConfigurationPath, FileMode.Open))
                {
                    result = serializer.ReadObject(ms) as Configuration;
                    ms.Flush();
                    ms.Close();
                }
            }
            if (result == null)
            {
                result = new Configuration();
            }

            return result;
        }
    }
}
