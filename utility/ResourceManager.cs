using BobNet.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BobNet.utility
{
    public class ResourceManager
    {
        string fileLocation;
        public ResourceManager()
        {
            fileLocation = System.AppDomain.CurrentDomain.BaseDirectory + @"Resource.xml";

        }

        public List<ResourceProperties> LoadData()
        {
            List<ResourceProperties> resourceList;

            XDocument doc = XDocument.Load(fileLocation);
            resourceList = (from BogieProperties in doc.Descendants("Resource")
                         orderby BogieProperties.Element("Name").Value
                         select new ResourceProperties
                         {
                             Name = BogieProperties.Element("Name").Value,
                             Stats = BogieProperties.Element("Stats").Value,
                         }).ToList();

            return resourceList;

        }
    }
}
