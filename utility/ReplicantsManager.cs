using BobNet.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BobNet.utility
{
    public class ReplicantsManager
    {
        string fileLocation;
        public ReplicantsManager()
        {
            fileLocation = System.AppDomain.CurrentDomain.BaseDirectory + @"Replicants.xml";

        }

        public List<ReplicantsProperties> LoadData()
        {
            List<ReplicantsProperties> replicantsList;

            XDocument doc = XDocument.Load(fileLocation);
            replicantsList = (from BogieProperties in doc.Descendants("Replicants")
                         orderby BogieProperties.Element("Name").Value
                         select new ReplicantsProperties
                         {
                             Name = BogieProperties.Element("Name").Value,
                             Stats = BogieProperties.Element("Stats").Value,
                         }).ToList();

            return replicantsList;

        }
    }
}
