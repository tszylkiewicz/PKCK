using System.ComponentModel;
using System.Windows.Input;

namespace ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    { 
        public ICommand Click_Save { get; }
        public ICommand Click_Read { get; }        

        public MainViewModel()
        {           
            Click_Save = new RelayCommand(SaveXml);
            Click_Read = new RelayCommand(ReadXml);
            System.Console.WriteLine("utworzenie viewmodel");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName_)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName_));
        }

        public void SaveXml()
        {
            System.Console.WriteLine("zapis do xml");
        }

        public void ReadXml()
        {
            System.Console.WriteLine("odczyt z pliku xml");
        }
    }
}
