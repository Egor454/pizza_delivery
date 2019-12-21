using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pizza_delivery.ViewModel
{
    public interface IValueConverter
    {
      void  Convert(object value, Type targetType, object parameter, CultureInfo culture);
       void ConvertBack(object value, Type targetType, object parameter, CultureInfo culture);
    }
}
