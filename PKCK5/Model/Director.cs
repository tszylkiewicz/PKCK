using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Model
{
    [XmlRoot("Director")]
    public class Director
    {
        [XmlAttribute("directorID")]
        public string DirectorId { get; set; }

        [XmlElement("Firstname")]
        public string Firstname { get; set; }

        [XmlElement("Lastname")]
        public string Lastname { get; set; }

        [XmlElement("BirthDate")]
        public string BirthDate { get; set; }
    }
}
