using Microsoft.VisualStudio.TestTools.UnitTesting;
using PKCK;
using PKCK.Model;
using System;
using System.Collections.Generic;

namespace Tests
{
    [TestClass]
    public class XMLSerializationTest
    {
        [TestMethod]
        public void Generation()
        {
            Random random = new Random();

            ModelCollection collection = new ModelCollection();
            List<Director> directors = new List<Director>();
            List<Movie> movies = new List<Movie>();

            // Create Directors
            Director AnnaBoden = new Director()
            {
                Firstname = "Anna",
                Lastname = "Boden",
                BirthDate = new DateTime(1976, 9, 20)
            };

            // Create Movies
            Movie KapitanMarvel = new Movie()
            {
                Title = "Kapitan Marvel",
                Director = AnnaBoden,
                Genre = { Genre.Action, Genre.SciFi },
                ReleaseDate = new DateTime(2019, 3, 6),
                Duration = 124,
                ProductionPlaces = {"USA"}
            };

            // Serialize
            collection.Directors = directors;
            collection.Movies = movies;
            XMLSerializer serializer = new XMLSerializer();
            serializer.Serialize(collection, "collection.xml");
        }
    }
}
