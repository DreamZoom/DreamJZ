using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Xml.Serialization;

namespace Dream
{
    public class ConfigProvider
    {
        public static string ConfigPath = "/Config";
        public static TConfig Load<TConfig>(string key=null)
        {
            string filename = (key == null ? string.Format("{0}.xml", typeof(TConfig).Name) : string.Format("{0}_{1}.xml", typeof(TConfig).Name, key));
            string filePath = string.Format("{0}/{1}", HttpContext.Current.Server.MapPath(ConfigPath),filename);

            using (FileStream file = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Read))
            {
                XmlSerializer xmlSearializer = new XmlSerializer(typeof(TConfig));
                TConfig config = (TConfig)xmlSearializer.Deserialize(file);
                return config;
            }
        }

        public static bool Save<TConfig>(TConfig config, string key = null)
        {
            string filename = (key == null ? string.Format("{0}.xml", typeof(TConfig).Name) : string.Format("{0}_{1}.xml", typeof(TConfig).Name, key));
            string filePath = string.Format("{0}/{1}", HttpContext.Current.Server.MapPath(ConfigPath), filename);

            using (FileStream file = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write))
            {
                XmlSerializer xmlSearializer = new XmlSerializer(typeof(TConfig));
                xmlSearializer.Serialize(file,config);
                file.Close();
                file.Dispose();
                return true;
            }
        }
    }
}
