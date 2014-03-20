using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RainbowMage.ActLocalizer
{
    [Serializable]
    public class Config
    {
        public bool IsEnabled { get { return !(string.IsNullOrEmpty(this.Locale) || this.Locale == "en-US"); } }
        public string Locale { get; set; }
        public bool ExportOriginalOnNextBoot { get; set; }

        public Config()
        {
            this.Locale = "en-US";
            this.ExportOriginalOnNextBoot = false;
        }

        public void Save(string xmlPath)
        {
            var serializer = new XmlSerializer(typeof(Config));
            using (var stream = new FileStream(xmlPath, FileMode.Create, FileAccess.Write))
            {
                serializer.Serialize(stream, this);
            }
        }

        public static Config Load(string xmlPath)
        {
            var serializer = new XmlSerializer(typeof(Config));
            using (var stream = new FileStream(xmlPath, FileMode.Open, FileAccess.Read))
            {
                return serializer.Deserialize(stream) as Config;
            }
        }
    }
}
