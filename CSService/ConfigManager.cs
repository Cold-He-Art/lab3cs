using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace CSService
{
    class ConfigManager
    {
        private JsonParser jsonObject;
        private XmlParser xmlObject;
        private List<Functional> func;

        public ConfigManager()
        {
            jsonObject = new JsonParser();
            xmlObject = new XmlParser();
            func = new List<Functional>();
        }

        internal List<Functional> GetOptions()
        {
            string[] files = new string[50];
            files = Directory.GetFiles(@"C:\Users\karti\source\repos\NashService");
            foreach (string file in files)
            {
                if (Path.GetExtension(file) == ".json") func = jsonObject.Parse();
                else if (Path.GetExtension(file) == ".xml") func = xmlObject.Parse();
            }

            return func;
        }

    }
}
