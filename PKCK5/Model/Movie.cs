using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Model
{
    [XmlRoot("Movie")]
    public class Movie
    {
        [XmlAttribute("movieID")]
        public string MovieId { get; set; }

        [XmlAttribute("directorID")]
        public string DirectorId { get; set; }

        [XmlElement("Title")]
        public string Title { get; set; }

        [XmlElement("ReleaseDate")]
        public string ReleaseDate { get; set; }

        [XmlElement("Duration")]
        public Duration Duration { get; set; }

        [XmlElement("Cost")]
        public Cost Cost { get; set; }

        [XmlArray("Genres")]
        [XmlArrayItem("Genre")]
        public List<GenreEnum> Genres { get; set; }

        [XmlArray("ProductionPlaces")]
        [XmlArrayItem("Place")]
        public List<PlaceEnum> ProductionPlaces { get; set; }

        public Movie()
        {
            Cost = new Cost();
            Duration = new Duration();
            ProductionPlaces = new List<PlaceEnum>();
            Genres = new List<GenreEnum>();
        }
    }

}
