using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Model
{
    [XmlRoot("Cost")]
    public class Cost
    {
        [XmlAttribute("currency")]
        public string Id { get; set; }

        [XmlText]
        public string Value { get; set; }
    }
}
