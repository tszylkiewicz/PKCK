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

        public Director SelectedDirectorr { get; set; }
        public Movie SelectedMoviee {get; set; }

        public Collection Collection { get; set; }    
        public Director NewDirector { get; set; }
        public Movie NewMovie { get; set; }

        public string Price { get; set; }
        public ICommand Click_Add_Director { get; }
        public ICommand Click_Remove_Director { get; }
        public ICommand Click_Add_Movie { get; }
        public ICommand Click_Remove_Movie { get; }

        public ICommand Click_Load_Xml { get; }
        public ICommand Click_Save_Xml { get; }
        public ICommand Click_Save_To_Txt { get; }
        public ICommand Click_Save_To_Xhtml { get; }
        public ICommand Click_Save_To_Pdf { get; }
        public ICommand Click_Save_To_Svg { get; }
        public event PropertyChangedEventHandler PropertyChanged;

        public XmlViewModel()
        {
            Click_Add_Director = new RelayCommand(AddDirector);
            Click_Remove_Director = new RelayCommand(RemoveDirector);
            Click_Add_Movie = new RelayCommand(AddMovie);
            Click_Remove_Movie = new RelayCommand(RemoveMovie);
            Click_Load_Xml = new RelayCommand(LoadXml);
            Click_Save_Xml = new RelayCommand(SaveToXml);
            Click_Save_To_Txt = new RelayCommand(TransformToTxt);
            Click_Save_To_Xhtml = new RelayCommand(TransformToXhtml);
            Click_Save_To_Pdf = new RelayCommand(TransformToPdf);
            Click_Save_To_Svg = new RelayCommand(TransformToSvg);

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

            Directors.Add(NewDirector.DirectorId);
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
        private void RemoveDirector()
        {
            Collection.Directors.Remove(SelectedDirectorr);
        }
        private void RemoveMovie()
        {
            Collection.Movies.Remove(SelectedMoviee);
        }
        private void LoadXml()
        {
            //string filename = "C:\\Users\\Windows\\Documents\\PKCK\\Docs\\moviesHandWritten.xml";
            String filename = XmlViewModelHelper.OpenDialog("Załaduj plik .xml", "xml");
            ValidateXmlXsd(filename);
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
            //string filename = "D:\\Repository\\PKCK\\Docs\\newXml.xml";
            String filename = XmlViewModelHelper.OpenDialog("Zapisz do pliku .xml", "xml");
            XmlSerializer serializer = new XmlSerializer(typeof(Collection));

            using (Stream reader = new FileStream(filename, FileMode.Create))
            {
                serializer.Serialize(reader, Collection);
            }
        }
        private void TransformToXml()
        {
            //FileInfo xslt = new FileInfo("D:\\Repository\\PKCK\\Docs\\documentTemplate.xsl");
            //FileInfo input = new FileInfo("D:\\Repository\\PKCK\\Docs\\moviesHandWritten.xml");
            //FileInfo output = new FileInfo("D:\\Repository\\PKCK\\Docs\\testy\\xmlTest.xml");
            FileInfo xslt = new FileInfo(XmlViewModelHelper.OpenDialog("Załaduj plik XSLT do podsumowywującej transformacji .xml", "xsl"));
            FileInfo input = new FileInfo(XmlViewModelHelper.OpenDialog("Załaduj wejściowy plik .xml", "xml"));
            FileInfo output = new FileInfo(XmlViewModelHelper.OpenDialog("Załaduj wyjściowy plik .xml", ""));

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

            //XPathDocument myXPathDoc = new XPathDocument("D:\\Repository\\PKCK\\Docs\\testy\\xmlTest.xml");
            XPathDocument myXPathDoc = new XPathDocument(XmlViewModelHelper.OpenDialog("Załaduj wejściowy plik XML", "xml"));
            XslCompiledTransform myXslTrans = new XslCompiledTransform();
            //myXslTrans.Load("D:\\Repository\\PKCK\\Docs\\txtTemplate.xsl");
            myXslTrans.Load(XmlViewModelHelper.OpenDialog("Załaduj plik XSLT do transformacji .txt", "xsl"));
            //XmlTextWriter myWriter = new XmlTextWriter("D:\\Repository\\PKCK\\Docs\\testy\\txtTest.txt", null);
            XmlTextWriter myWriter = new XmlTextWriter(XmlViewModelHelper.OpenDialog("Załaduj wyjściowy plik TXT", "txt"), null);
            myXslTrans.Transform(myXPathDoc, null, myWriter);
        }
        private void TransformToXhtml()
        {
            TransformToXml();
            //XPathDocument myXPathDoc = new XPathDocument("D:\\Repository\\PKCK\\Docs\\testy\\xmlTest.xml");
            XPathDocument myXPathDoc = new XPathDocument(XmlViewModelHelper.OpenDialog("Załaduj wejściowy plik XML", "xml"));
            XslCompiledTransform myXslTrans = new XslCompiledTransform();
            //myXslTrans.Load("D:\\Repository\\PKCK\\Docs\\xhtmlTemplate.xsl");
            myXslTrans.Load(XmlViewModelHelper.OpenDialog("Załaduj plik XSLT do transformacji .XHTML", "xsl"));
            //XmlTextWriter myWriter = new XmlTextWriter("D:\\Repository\\PKCK\\Docs\\testy\\xhtmlTest.xhtml", null);
            XmlTextWriter myWriter = new XmlTextWriter(XmlViewModelHelper.OpenDialog("Załaduj wyjściowy plik XHTML", "xhtml"), null);
            myXslTrans.Transform(myXPathDoc, null, myWriter);
        }
        private void TransformToPdf()
        {
            TransformToXml();
            //XPathDocument myXPathDoc = new XPathDocument("D:\\Repository\\PKCK\\Docs\\testy\\xmlTest.xml");
            XPathDocument myXPathDoc = new XPathDocument(XmlViewModelHelper.OpenDialog("Załaduj wejściowy plik XML", "xml"));
            XslCompiledTransform myXslTrans = new XslCompiledTransform();
            //myXslTrans.Load("D:\\Repository\\PKCK\\Docs\\pdfTemplate.xsl");
            myXslTrans.Load(XmlViewModelHelper.OpenDialog("Załaduj plik XSLT do transformacji .PDF", "xsl"));
            //XmlTextWriter myWriter = new XmlTextWriter("D:\\Repository\\PKCK\\Docs\\testy\\pdfTest.fo", null);
            String foFile = XmlViewModelHelper.OpenDialog("Załaduj pośredniczący plik FO (.fo)", "fo");
            XmlTextWriter myWriter = new XmlTextWriter(foFile, null);
            myXslTrans.Transform(myXPathDoc, null, myWriter);
            myWriter.Close();
            FonetDriver driver = FonetDriver.Make();
            //driver.Render("D:\\Repository\\PKCK\\Docs\\testy\\pdfTest.fo", "D:\\Repository\\PKCK\\Docs\\testy\\pdfTest.pdf");
            driver.Render(foFile, XmlViewModelHelper.OpenDialog("Załaduj wyjściowy plik PDF", "pdf"));
        }
        private void TransformToSvg()
        {
            TransformToXml();
            //XPathDocument myXPathDoc = new XPathDocument("D:\\Repository\\PKCK\\Docs\\testy\\xmlTest.xml");
            XPathDocument myXPathDoc = new XPathDocument(XmlViewModelHelper.OpenDialog("Załaduj wejściowy plik XML", "xml"));
            XslCompiledTransform myXslTrans = new XslCompiledTransform();
            //myXslTrans.Load("D:\\Repository\\PKCK\\Docs\\svgTemplate.xsl");
            myXslTrans.Load(XmlViewModelHelper.OpenDialog("Załaduj plik XSLT do transformacji .SVG", "xsl"));
            //XmlTextWriter myWriter = new XmlTextWriter("D:\\Repository\\PKCK\\Docs\\testy\\svgTest.svg", null);
            XmlTextWriter myWriter = new XmlTextWriter(XmlViewModelHelper.OpenDialog("Załaduj wyjściowy plik SVG", "svg"), null);
            myXslTrans.Transform(myXPathDoc, null, myWriter);

        }
        #endregion

        public void ValidateXmlXsd(String xmlFileName)
        {
            XmlDocument xml = new XmlDocument();
            //xml.Load("..\\..\\..\\..\\Docs\\moviesHandWritten.xml");
            xml.Load(xmlFileName);
            //xml.Schemas.Add(null, "..\\..\\..\\..\\Docs\\schema.xsd");
            xml.Schemas.Add(null, XmlViewModelHelper.OpenDialog("Załaduj scheme", "xsd"));

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
