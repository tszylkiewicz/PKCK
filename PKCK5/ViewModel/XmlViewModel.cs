using Fonet;
using Model;
using Saxon.Api;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;
using System.Xml.XPath;
using System.Xml.Xsl;

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
        public ICommand Click_Save_To_Txt { get; }
        public ICommand Click_Save_To_Xhtml { get; }
        public ICommand Click_Save_To_Pdf { get; }
        public event PropertyChangedEventHandler PropertyChanged;

        public XmlViewModel()
        {
            Click_Add_Director = new RelayCommand(AddDirector);
            Click_Add_Movie = new RelayCommand(AddMovie);
            Click_Load_Xml = new RelayCommand(LoadXml);
            Click_Save_Xml = new RelayCommand(SaveToXml);
            Click_Save_To_Txt = new RelayCommand(TransformToTxt);
            Click_Save_To_Xhtml = new RelayCommand(TransformToXhtml);
            Click_Save_To_Pdf = new RelayCommand(TransformToPdf);

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
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
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
            ValidateXmlXsd();

            string filename = "D:\\Repository\\PKCK\\Docs\\moviesHandWritten.xml";
            XmlSerializer serializer = new XmlSerializer(typeof(Collection));

            using (Stream reader = new FileStream(filename, FileMode.Open))
            {
                Collection = (Collection)serializer.Deserialize(reader);
            }

            Directors = Collection.GetAllDirectorKeys();
            Console.WriteLine(Collection.Movies[0].Cost.Value);
        }
        private void SaveToXml()
        {
            string filename = "D:\\Repository\\PKCK\\Docs\\newXml.xml";
            XmlSerializer serializer = new XmlSerializer(typeof(Collection));

            using (Stream reader = new FileStream(filename, FileMode.Create))
            {
                serializer.Serialize(reader, Collection);
            }
        }
        private void TransformToXml()
        {
            FileInfo xslt = new FileInfo("D:\\Repository\\PKCK\\Docs\\documentTemplate.xsl");
            FileInfo input = new FileInfo("D:\\Repository\\PKCK\\Docs\\moviesHandWritten.xml");
            FileInfo output = new FileInfo("D:\\Repository\\PKCK\\Docs\\testy\\xmlTest.xml");

            // Compile stylesheet
            Processor processor = new Processor();
            XsltCompiler compiler = processor.NewXsltCompiler();
            XsltExecutable executable = compiler.Compile(new Uri(xslt.FullName));

            // Do transformation to a destination
            DomDestination destination = new DomDestination();
            using (FileStream inputStream = input.OpenRead())
            {
                var transformer = executable.Load();
                transformer.SetInputStream(inputStream, new Uri(input.DirectoryName));
                transformer.Run(destination);
            }

            // Save result to a file (or whatever else you wanna do)
            destination.XmlDocument.Save(output.FullName);
        }
        private void TransformToTxt()
        {
            TransformToXml();

            XPathDocument myXPathDoc = new XPathDocument("D:\\Repository\\PKCK\\Docs\\testy\\xmlTest.xml");
            XslCompiledTransform myXslTrans = new XslCompiledTransform();
            myXslTrans.Load("D:\\Repository\\PKCK\\Docs\\txtTemplate.xsl");
            XmlTextWriter myWriter = new XmlTextWriter("D:\\Repository\\PKCK\\Docs\\testy\\txtTest.txt", null);
            myXslTrans.Transform(myXPathDoc, null, myWriter);
        }
        private void TransformToXhtml()
        {
            TransformToXml();
            XPathDocument myXPathDoc = new XPathDocument("D:\\Repository\\PKCK\\Docs\\testy\\xmlTest.xml");
            XslCompiledTransform myXslTrans = new XslCompiledTransform();
            myXslTrans.Load("D:\\Repository\\PKCK\\Docs\\xhtmlTemplate.xsl");
            XmlTextWriter myWriter = new XmlTextWriter("D:\\Repository\\PKCK\\Docs\\testy\\xhtmlTest.xhtml", null);
            myXslTrans.Transform(myXPathDoc, null, myWriter);
        }
        private void TransformToPdf()
        {
            TransformToXml();
            XPathDocument myXPathDoc = new XPathDocument("D:\\Repository\\PKCK\\Docs\\testy\\xmlTest.xml");
            XslCompiledTransform myXslTrans = new XslCompiledTransform();
            myXslTrans.Load("D:\\Repository\\PKCK\\Docs\\pdfTemplate.xsl");
            XmlTextWriter myWriter = new XmlTextWriter("D:\\Repository\\PKCK\\Docs\\testy\\pdfTest.fo", null);
            myXslTrans.Transform(myXPathDoc, null, myWriter);
            myWriter.Close();
            FonetDriver driver = FonetDriver.Make();
            driver.Render("D:\\Repository\\PKCK\\Docs\\testy\\pdfTest.fo", "D:\\Repository\\PKCK\\Docs\\testy\\pdfTest.pdf");
        }
        private void TransformToSvg()
        {
            TransformToXml();
            XPathDocument myXPathDoc = new XPathDocument("D:\\Repository\\PKCK\\Docs\\testy\\xmlTest.xml");
            XslCompiledTransform myXslTrans = new XslCompiledTransform();
            myXslTrans.Load("D:\\Repository\\PKCK\\Docs\\svgTemplate.xsl");
            XmlTextWriter myWriter = new XmlTextWriter("D:\\Repository\\PKCK\\Docs\\testy\\svgTest.svg", null);
            myXslTrans.Transform(myXPathDoc, null, myWriter);

        }
        #endregion

        public void ValidateXmlXsd()
        {
            XmlDocument xml = new XmlDocument();
            xml.Load("D:\\Repository\\PKCK\\Docs\\moviesHandWritten.xml");
            xml.Schemas.Add(null, "D:\\Repository\\PKCK\\Docs\\schema.xsd");

            try
            {
                xml.Validate(null);
            }
            catch (XmlSchemaValidationException)
            {
                MessageBox.Show("XML is not valid against xsd file", "Validation result",
                MessageBoxButton.OK, MessageBoxImage.Error);
            }

            MessageBox.Show("Validation correct", "Validation result",
            MessageBoxButton.OK, MessageBoxImage.None);
        }

    }
}
