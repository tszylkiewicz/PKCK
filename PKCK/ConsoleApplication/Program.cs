using PKCK;
using PKCK.Model;
using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Collection collection = new Collection();

            // Create Genre
            List<Genre> genres = new List<Genre>();
            genres.Add(Genre.Action);
            genres.Add(Genre.SciFi);

            // Create Places
            List<Place> places = new List<Place>();
            places.Add(Place.USA);
            places.Add(Place.Poland);


            // Create Directors
            List<Director> directors = new List<Director>();
            directors.Add(new Director("Anna", "Boden", new DateTime(1976, 9, 20)));
            directors.Add(new Director("Jon", "Favreau", new DateTime(1966, 10, 19)));
            directors.Add(new Director("Ridley ", "Scott", new DateTime(1937, 11, 30)));
            directors.Add(new Director("David ", "Ayer", new DateTime(1968, 1, 18)));


            // Create Movies           
            List<Movie> movies = new List<Movie>();
            movies.Add(new Movie("Kapitan Marvel", directors[0], new Genre[] { Genre.Action, Genre.SciFi }, 124, new DateTime(2019, 3, 6), new Place[] { Place.USA }));
            movies.Add(new Movie("Iron Man", directors[1], new Genre[] { Genre.Action, Genre.SciFi }, 126, new DateTime(2008, 4, 14), new Place[] { Place.USA }));
            movies.Add(new Movie("Alien Coventant", directors[2], new Genre[] { Genre.SciFi, Genre.Horror }, 122, new DateTime(2017, 5, 4), new Place[] { Place.USA, Place.UK }));
            movies.Add(new Movie("Deadpool", directors[1], new Genre[] { Genre.Action, Genre.Comedy, Genre.SciFi }, 108, new DateTime(2016, 1, 21), new Place[] { Place.USA }));
            movies.Add(new Movie("Suicide Squad", directors[3], new Genre[] { Genre.Action, Genre.SciFi }, 123, new DateTime(2016, 6, 5), new Place[] { Place.USA, Place.Canada }));


            // Serialize
            collection.Directors = directors;
            collection.Movies = movies;
            XMLSerializer serializer = new XMLSerializer();
            serializer.Serialize(collection, "../../../../Docs/movies.xml");
        }
    }
}
