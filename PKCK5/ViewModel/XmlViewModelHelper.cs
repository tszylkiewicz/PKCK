using System;
using Microsoft.Win32;

namespace ViewModel
{
    public class XmlViewModelHelper
    {
        public static string OpenDialog(String title, String fileFormat)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = title;
            if(fileFormat != "")
            {
                ofd.Filter = fileFormat + " (*." + fileFormat + ")|*." + fileFormat;
            }
            var result = ofd.ShowDialog();
            return result == true ? ofd.FileName : "";
        } 
    }
}
