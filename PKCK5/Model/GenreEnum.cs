using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Model
{
    public enum GenreEnum
    {
        [XmlEnum(Name = "Action")]
        Action,
        [XmlEnum(Name = "SciFi")]
        SciFi,
        [XmlEnum(Name = "Horror")]
        Horror,
        [XmlEnum(Name = "Comedy")]
        Comedy,
        [XmlEnum(Name = "Drama")]
        Drama,
        [XmlEnum(Name = "War")]
        War,
        [XmlEnum(Name = "Fantasy")]
        Fantasy,
        [XmlEnum(Name = "Adventure")]
        Adventure,
        [XmlEnum(Name = "Thriller")]
        Thriller
    }
}
