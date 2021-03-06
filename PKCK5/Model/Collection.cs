﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Model
{
    [XmlRoot("Collection")]
    public class Collection
    {
        [XmlArray("Directors")]
        [XmlArrayItem("Director")]
        public ObservableCollection<Director> Directors { get; set; }

        [XmlArray("Movies")]
        [XmlArrayItem("Movie")]
        public ObservableCollection<Movie> Movies { get; set; }

        public ObservableCollection<string> GetAllDirectorKeys()
        {
            ObservableCollection<string> result = new ObservableCollection<string>();
            foreach (Director director in Directors)
            {
                result.Add(director.DirectorId);
                //result.Add(director.Firstname + " " + director.Lastname);
            }
            return result;
        }

        public string GetNextDirectorKey()
        {
            List<Director> temp = new List<Director>();
            foreach (Director d in Directors)
            {
                temp.Add(d);
            }
            temp.Sort(delegate (Director c1, Director c2) { return c1.DirectorId.CompareTo(c2.DirectorId); });
            int value = System.Convert.ToInt32(Directors.Last().DirectorId.Substring(1)) + 1;
            return "D" + value.ToString().PadLeft(3, '0');
        }

        public string GetNextMovieKey()
        {
            List<Movie> temp = new List<Movie>();
            foreach (Movie m in Movies)
            {
                temp.Add(m);
            }
            temp.Sort(delegate (Movie c1, Movie c2) { return c1.MovieId.CompareTo(c2.MovieId); });
            int value = System.Convert.ToInt32(Movies.Last().MovieId.Substring(1)) + 1;
            return "M" + value.ToString().PadLeft(3, '0');
        }
    }
}
