using BobNet.model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace BobNet.utility
{
    public class WindowManager
    {
        string fileLocation;
        public WindowManager()
        {
            fileLocation = System.AppDomain.CurrentDomain.BaseDirectory + @"WindowManager.xml";

        }

        public List<ScreenProperties> LoadData(string screenName)
        {
            List<ScreenProperties> screenList;

            XDocument doc = XDocument.Load(fileLocation);
            screenList = (from screen in doc.Descendants("Screen")
                         where screen.Element("ScreenName").Value.Equals(screenName)
                         orderby screen.Element("ScreenName").Value
                         select new ScreenProperties
                         {
                             ScreenName = screen.Element("ScreenName").Value,
                             ScreenTop = screen.Element("ScreenTop").Value,
                             ScreenLeft = screen.Element("ScreenLeft").Value,
                         }).ToList();

            return screenList;

        }

        //public void DeleteData(string toDelete) //            DeleteData("Radar1");
        //{

        //    if (System.Windows.MessageBox.Show("Do you Really Want To Delete This Movie ?", "Delete Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
        //    {
        //        XDocument doc = XDocument.Load(@"C:\0\Workspace\bin\Debug\MovieDB.xml");
        //        foreach (var item in doc.Descendants("Screen"))
        //        {
        //            if (item.Element("ScreenName").Value == toDelete)
        //            {
        //                ((XElement)item.Element("ScreenName")).Parent.Remove();
        //                doc.Save(@"C:\0\Workspace\bin\Debug\MovieDB.xml");
        //                break;
        //            }
        //        }
        //        LoadData();

        //    }
        //}

        public void WriteToXmlFile(ScreenProperties screen, bool isUpdate)
        {
            #region Add New
            if (!isUpdate)
            {
                XmlDocument xmlDoc = new XmlDocument();
                using (FileStream fs = new FileStream(fileLocation, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    xmlDoc.Load(fs);
                    fs.Close();
                }

                XmlElement newScreen = xmlDoc.CreateElement("Screen");
                XmlElement screenName = xmlDoc.CreateElement("ScreenName");
                screenName.InnerText = screen.ScreenName;
                newScreen.AppendChild(screenName);
                XmlElement screenTop = xmlDoc.CreateElement("ScreenTop");
                screenTop.InnerText = screen.ScreenTop;
                newScreen.AppendChild(screenTop);
                XmlElement screenLeft = xmlDoc.CreateElement("ScreenLeft");
                screenLeft.InnerText = screen.ScreenLeft;
                newScreen.AppendChild(screenLeft);


                xmlDoc.DocumentElement.InsertAfter(newScreen, xmlDoc.DocumentElement.LastChild);
                using (FileStream fsxml = new FileStream(fileLocation, FileMode.Truncate, FileAccess.Write, FileShare.ReadWrite))
                {
                    xmlDoc.Save(fsxml);
                    fsxml.Close();
                }

            }
            #endregion 
            #region Update
            else
            {
                XDocument doc = XDocument.Load(fileLocation);
                foreach (var item in doc.Descendants("Screen"))
                {
                    if (item.Element("ScreenName").Value == screen.ScreenName)
                    {
                        item.Element("ScreenTop").SetValue(screen.ScreenTop);
                        item.Element("ScreenLeft").SetValue(screen.ScreenLeft);
                        doc.Save(fileLocation);
                        break;
                    }
                }
            }
            #endregion 
        }
    }
}
