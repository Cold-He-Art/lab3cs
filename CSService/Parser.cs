using System.Collections.Generic;
using System;
using System.IO;
using System.Xml.Serialization;
using System.Text.Json;

namespace CSService
{
    public interface IParser 
    {
        List<Functional> Parse();
    }


    internal class XmlParser : IParser
    {
        public virtual List<Functional> Parse()
        {
            string Xmlpath = @"C:\Users\karti\source\repos\NashService\config.xml";
            List<Functional> fullXMLOptions = new List<Functional>(); 
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Functional));
            Functional XmlOptions = new Functional();

            using (var xmlRead = new FileStream(Xmlpath, FileMode.OpenOrCreate))
            {
                XmlOptions = (Functional)xmlSerializer.Deserialize(xmlRead);
            }

            if (XmlOptions != null) 
                fullXMLOptions.Add(XmlOptions);
            else
                throw new NullReferenceException();


            return fullXMLOptions;
        }

    }


    internal class JsonParser : IParser
    {
        private List<Functional> optionsJson = new List<Functional>(); 
        private string jsonString; 
        public virtual List<Functional> Parse()
        {
            using (var jsonStream = new StreamReader(@"C:\Users\karti\source\repos\NashService\appsettings.json"))
            {
                jsonString = jsonStream.ReadToEnd();
            }
            Functional optionJson = JsonSerializer.Deserialize<Functional>(jsonString);

            if (optionJson != null) optionsJson.Add(optionJson);
            else throw new NullReferenceException();

            return optionsJson;
        }
    }
}