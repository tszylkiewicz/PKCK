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
            directors.Add(new Director("Ridley", "Scott", new DateTime(1937, 11, 30)));
            directors.Add(new Director("David", "Ayer", new DateTime(1968, 1, 18)));
            directors.Add(new Director("Alex", "Garland", new DateTime(1970, 5, 26)));
            directors.Add(new Director("Wojciech", "Smarzowski", new DateTime(1963, 1, 18)));      
            directors.Add(new Director("George", "Miller", new DateTime(1945, 3, 3)));
            directors.Add(new Director("Denis", "Villeneuve", new DateTime(1967, 10, 3)));     
            directors.Add(new Director("Joss", "Whedon", new DateTime(1964, 6, 23)));
            directors.Add(new Director("Scott", "Derrickson", new DateTime(1966, 7, 16)));
            directors.Add(new Director("James", "Mangold", new DateTime(1963, 12, 16)));
            directors.Add(new Director("Guillermo", "del Torro", new DateTime(1964, 10, 9)));
            directors.Add(new Director("Steven", "Spielberg", new DateTime(1946, 12, 18)));
            directors.Add(new Director("Morten", "Tyldum", new DateTime(1967, 5, 19)));

            // Create Movies           
            List<Movie> movies = new List<Movie>();
            movies.Add(new Movie("Kapitan Marvel", directors[0], new Genre[] { Genre.Action, Genre.SciFi }, 124, new DateTime(2019, 3, 6), new Place[] { Place.USA }));
            movies.Add(new Movie("Iron Man", directors[1], new Genre[] { Genre.Action, Genre.SciFi }, 126, new DateTime(2008, 4, 14), new Place[] { Place.USA }));
            movies.Add(new Movie("Alien Coventant", directors[2], new Genre[] { Genre.SciFi, Genre.Horror }, 122, new DateTime(2017, 5, 4), new Place[] { Place.USA, Place.UK }));
            movies.Add(new Movie("Deadpool", directors[1], new Genre[] { Genre.Action, Genre.Comedy, Genre.SciFi }, 108, new DateTime(2016, 1, 21), new Place[] { Place.USA }));
            movies.Add(new Movie("Suicide Squad", directors[3], new Genre[] { Genre.Action, Genre.SciFi }, 123, new DateTime(2016, 6, 5), new Place[] { Place.USA, Place.Canada }));
            movies.Add(new Movie("Ex Machina", directors[4], new Genre[] { Genre.Thriller, Genre.SciFi }, 108, new DateTime(2015, 1, 21), new Place[] { Place.UK }));
            movies.Add(new Movie("Wołyń", directors[5], new Genre[] { Genre.War, Genre.Drama }, 150, new DateTime(2016, 9, 23), new Place[] { Place.Poland }));       
            movies.Add(new Movie("Mad Max: Fury Road", directors[6], new Genre[] { Genre.Action, Genre.SciFi }, 120, new DateTime(2015, 5, 7), new Place[] { Place.USA, Place.Australia }));        
            movies.Add(new Movie("Blade Runner 2049", directors[7], new Genre[] { Genre.Thriller, Genre.SciFi }, 163, new DateTime(2017, 10, 3), new Place[] { Place.USA, Place.Canada, Place.UK, Place.Hungary }));
            movies.Add(new Movie("Avengers: Age of Ultron", directors[8], new Genre[] { Genre.Action, Genre.SciFi }, 141, new DateTime(2015, 4, 13), new Place[] { Place.USA }));
            movies.Add(new Movie("Doctor Strange", directors[9], new Genre[] { Genre.Fantasy, Genre.Adventure }, 115, new DateTime(2016, 10, 13), new Place[] { Place.USA }));
            movies.Add(new Movie("Logan", directors[10], new Genre[] { Genre.Action, Genre.SciFi, Genre.Drama }, 137, new DateTime(2017, 2, 17), new Place[] { Place.USA, Place.Canada, Place.Australia }));
            movies.Add(new Movie("The Shape of Water", directors[11], new Genre[] { Genre.Fantasy }, 119, new DateTime(2017, 9, 16), new Place[] { Place.USA }));
            movies.Add(new Movie("Brigde of Spies", directors[12], new Genre[] { Genre.Drama, Genre.Thriller }, 141, new DateTime(2015, 9, 10), new Place[] { Place.USA, Place.Germany, Place.India }));
            movies.Add(new Movie("Passengers", directors[13], new Genre[] { Genre.Adventure, Genre.SciFi }, 116, new DateTime(2016, 12, 14), new Place[] { Place.USA }));
            
            // Serialize
            collection.Directors = directors;
            collection.Movies = movies;
            XMLSerializer serializer = new XMLSerializer();
            serializer.Serialize(collection, "../../../../Docs/movies.xml");
        }
    }
}
