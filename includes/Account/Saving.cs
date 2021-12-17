using System.Xml;
using System.Threading;
using System;

namespace IntegrateOS
{
    public static class Saving
    {
        /// <summary>
        /// Saves a XML using background threading
        /// </summary>
        public static void Thread_XML()
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists("Settings\\user.xml"))
            {

                try
                {
                    doc.Load("Settings\\user.xml");
                    doc.SelectSingleNode("/integrateos/settings_themes/theme").InnerText = ((int)Themes.MetroTheme).ToString();
                    doc.SelectSingleNode("/integrateos/settings_themes/color").InnerText = ((int)Themes.MetroColor).ToString();
                    doc.Save("Settings\\user.xml");
                }
                catch(Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

        public static void XML()
        {
            new LoadingResponse(new Thread(() => Thread_XML()), "Saving the current settings").ShowDialog();
        }
    }
}
