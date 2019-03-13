using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PKCK.Model
{
    [DataContract(Namespace = "")]
    public class Movie
    {
        [DataMember(Order = 0)]
        public string Title { get; set; }
        [DataMember(Order = 1)]
        public Director Director { get; set; }
        [DataMember(Order = 2)]
        public List<Genre> Genres { get; set; }
        [DataMember(Order = 3)]
        public int Duration { get; set; }
        [DataMember(Order = 4)]
        public DateTime ReleaseDate { get; set; }
        [DataMember(Order = 5)]
        public List<Place> ProductionPlaces { get; set; }

        public Movie(string title, Director director, Genre[] genres, int duration, DateTime releaseDate, Place[] productionPlaces)
        {
            Title = title;
            Director = director;

            Genres = new List<Genre>();
            foreach(Genre g in genres)
            {
                Genres.Add(g);
            }

            Duration = duration;
            ReleaseDate = releaseDate;
            ProductionPlaces = new List<Place>();
            foreach(Place p in productionPlaces)
            {
                ProductionPlaces.Add(p);
            }
        }


        public Movie()
        {

        }
    }
}
