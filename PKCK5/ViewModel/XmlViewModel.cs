using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Serialization;

namespace ViewModel
{
    public class XmlViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<string> CurrencyList { get; }
        public ObservableCollection<string> TimeUnitList { get; }
        public ObservableCollection<string> GenreList { get; }
        public ObservableCollection<string> PlaceList { get; }
        public ObservableCollection<string> Directors { get; set; }

        public string SelectedCurrency { get; set; }
        public string SelectedTimeUnit { get; set; }
        public string SelectedGenre { get; set; }
        public string SelectedPlace { get; set; }
        public string SelectedDirector { get; set; }


        public Collection Collection { get; set; }
        public Director NewDirector { get; set; }
        public Movie NewMovie { get; set; }

        public string Price { get; set; }
        public ICommand Click_Add_Director { get; }
        public ICommand Click_Add_Movie { get; }
        public ICommand Click_Load_Xml { get; }
        public ICommand Click_Save_Xml { get; }
        public event PropertyChangedEventHandler PropertyChanged;

        public XmlViewModel()
        {
            Click_Add_Director = new RelayCommand(AddDirector);
            Click_Add_Movie = new RelayCommand(AddMovie);
            Click_Load_Xml = new RelayCommand(LoadXml);
            Click_Save_Xml = new RelayCommand(SaveXml);

            SelectedCurrency = "PLN";
            SelectedTimeUnit = "min";
            Collection = new Collection();            

            //Adding new elements
            NewDirector = new Director();
            NewMovie = new Movie();           
        
            //Combo lists
            CurrencyList = new ObservableCollection<string> { "PLN", "EUR", "USD" };
            TimeUnitList = new ObservableCollection<string> { "min", "h" };
            GenreList = new ObservableCollection<string>(Enum.GetNames(typeof(GenreEnum)));
            PlaceList = new ObservableCollection<string>(Enum.GetNames(typeof(PlaceEnum)));

            LoadXml();
        }

        #region private
        private void RaisePropertyChanged(string propertyName_)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName_));
        }
        private void AddDirector()
        {
            NewDirector.DirectorId = Collection.GetNextDirectorKey();
            DateTime enteredDate = Convert.ToDateTime(NewDirector.BirthDate);
            NewDirector.BirthDate = enteredDate.ToString("yyyy-MM-dd");            

            Collection.Directors.Add(NewDirector);
            NewDirector = new Director();
            Directors = Collection.GetAllDirectorKeys();
        }
        private void AddMovie()
        {
            NewMovie.MovieId = Collection.GetNextMovieKey();
            Collection.GetNextDirectorKey();
            NewMovie.DirectorId = SelectedDirector;
            DateTime enteredDate = Convert.ToDateTime(NewMovie.ReleaseDate);
            NewMovie.ReleaseDate = enteredDate.ToString("yyyy-MM-dd");
            NewMovie.Cost.Id = SelectedCurrency;
            NewMovie.Duration.Id = SelectedTimeUnit;

            PlaceEnum place;
            Enum.TryParse<PlaceEnum>(SelectedPlace, out place);
            NewMovie.ProductionPlaces.Add(place);

            GenreEnum genre;
            Enum.TryParse<GenreEnum>(SelectedPlace, out genre);
            NewMovie.Genres.Add(genre);

            Collection.Movies.Add(NewMovie);
            NewMovie = new Movie();
        }
        private void LoadXml()
        {
            string filename = "D:\\Repository\\PKCK\\Docs\\moviesHandWritten.xml";
            XmlSerializer serializer = new XmlSerializer(typeof(Collection));

            using (Stream reader = new FileStream(filename, FileMode.Open))
            {
                Collection = (Collection)serializer.Deserialize(reader);
            }

            Directors = Collection.GetAllDirectorKeys();
            Console.WriteLine(Collection.Movies[0].Cost.Value);
        }
        private void SaveXml()
        {
            string filename = "D:\\Repository\\PKCK\\Docs\\newXml.xml";
            XmlSerializer serializer = new XmlSerializer(typeof(Collection));

            using (Stream reader = new FileStream(filename, FileMode.Create))
            {
                serializer.Serialize(reader, Collection);
            }
        }
        #endregion


    }
}
