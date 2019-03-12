using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PKCK.Model
{
    [DataContract]
    public class Movie
    {
        [DataMember]
        public String Title { get; set; }
        [DataMember]
        public Director Director { get; set; }
        [DataMember]
        public List<Genre> Genre { get; set; }
        [DataMember]
        public int Duration { get; set; }
        [DataMember]
        public DateTime ReleaseDate { get; set; }
        [DataMember]
        public List<String> ProductionPlaces { get; set; }
    }
}
