using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Layqa.Service.Util
{
    public static class XMLReader
    {
        public static string[] GetKeys(string xml)
        {
            string[] keys = new string[] { };

            if (xml != null && xml != "")
            {
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.LoadXml(xml);

                XmlNodeList list = xmldoc.GetElementsByTagName("item");
                int i = 0;
                foreach (XmlElement node in list)
                {
                    keys[i++]=node.GetAttribute("key");
                }
            }

            return keys;
        }

        public static string GetValue(string xml, string key)
        {
            string value = string.Empty;

            if (xml!=null && xml!="")
            {
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.LoadXml(xml);

                XmlNodeList list = xmldoc.GetElementsByTagName("item");
                foreach (XmlElement node in list)
                {
                    if (node.GetAttribute("key") == key)
                    {
                        value = node.GetAttribute("value");
                        break;
                    }
                }
            }
            
            return value;
        }

        public static string SetValue(string xml, string key, string value)
        {
            if (xml == null || xml == string.Empty) xml = "<root />";

            XmlDocument xmldoc = new XmlDocument();
            xmldoc.LoadXml(xml);

            XmlNodeList list = xmldoc.GetElementsByTagName("item");

            bool matched = false;
            foreach (XmlElement node in list)
            {
                if (node.GetAttribute("key") == key)
                {
                    node.SetAttribute("value", value);
                    matched = true;
                    break;
                }
            }

            if (!matched)
            {
                /*
                XmlElement item = xmldoc.CreateElement("item");
                item.SetAttribute("key", key);
                item.SetAttribute("value", value);
                xmldoc.AppendChild(item);
                */

                XmlElement node = xmldoc.CreateElement("item");
                node.SetAttribute("key", key);
                node.SetAttribute("value", value);
                xmldoc.ChildNodes[0].AppendChild(node);
            }

            return xmldoc.OuterXml;
        }

    }
}
