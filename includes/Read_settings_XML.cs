using System;
using System.Xml;

namespace IntegrateOS
{
    public class Read_settings_XML : IDisposable
    {
        private XmlTextReader textReader;

        public Read_settings_XML(string path)
        {
            textReader = new XmlTextReader(path);
        }

        public void Dispose()
        {
            textReader.Dispose();
        }

        /// <summary>
        /// Check if the current node has the selected string name
        /// </summary>
        /// <param name="xmlNodeType">node</param>
        /// <param name="name">selected string name</param>
        /// <returns>a bool</returns>
        private bool Check(XmlTextReader xmlNodeType, string name)
        {
            return (xmlNodeType.NodeType == XmlNodeType.Element && xmlNodeType.Name == name);
        }

        /// <summary>
        /// Reads XML type format
        /// </summary>
        public void Read()
        {
            while (textReader.Read())
            {
                if (Check(textReader, "color")) Themes.MetroColor = GenerateColors.Generate_Metro(int.Parse(textReader.ReadElementString()));
                if (Check(textReader, "theme")) Themes.MetroTheme = GenerateColors.Generate_MetroTheme(int.Parse(textReader.ReadElementString()));
            }
        }
    }
}
