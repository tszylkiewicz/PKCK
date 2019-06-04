using Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace View.Converters
{
    public class ListToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value.GetType() == typeof(List<GenreEnum>))
            {
                return String.Join(", ", ((IEnumerable)value).OfType<GenreEnum>().ToArray());
            }
            if (value.GetType() == typeof(List<PlaceEnum>))
            {
                return String.Join(", ", ((IEnumerable)value).OfType<PlaceEnum>().ToArray());
            }
            return "Wrong type";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
