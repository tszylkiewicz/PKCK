using System;

namespace Model
{
    public class Movie
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public Director Director { get; set; }
        public int Duration { get; set; }
        public string Genre { get; set; }
        public string Production { get; set; }
        public DateTime ReleaseDate { get; set; }

        public Movie(string id, string title, Director director, int duration, string genre, string production, DateTime releaseDate)
        {
            this.Id = id;
            this.Title = title;
            this.Director = director;
            this.Duration = duration;
            this.Genre = genre;
            this.Production = production;
            this.ReleaseDate = releaseDate;
        }
    }
}
