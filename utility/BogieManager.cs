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
    public class BogieManager
    {
        string fileLocation;
        public BogieManager()
        {
            fileLocation = System.AppDomain.CurrentDomain.BaseDirectory + @"Bogie.xml";

        }

        public List<BogieProperties> LoadData()
        {
            List<BogieProperties> bogieList;

            XDocument doc = XDocument.Load(fileLocation);
            bogieList = (from BogieProperties in doc.Descendants("Bogie")
                          orderby BogieProperties.Element("Name").Value
                          select new BogieProperties
                          {
                              Name = BogieProperties.Element("Name").Value,
                              Stats = BogieProperties.Element("Stats").Value,
                          }).ToList();

            return bogieList;

        }
    }
}
