using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Model
{
    public enum PlaceEnum
    {
        [XmlEnum(Name = "USA")]
        USA,
        [XmlEnum(Name = "Poland")]
        Poland,
        [XmlEnum(Name = "UK")]
        UK,
        [XmlEnum(Name = "Australia")]
        Australia,
        [XmlEnum(Name = "Hungary")]
        Hungary,
        [XmlEnum(Name = "Germany")]
        Germany,
        [XmlEnum(Name = "India")]
        India,
        [XmlEnum(Name = "Canada")]
        Canada
    }
}
