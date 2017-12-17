using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace CsgoTactics.Converters
{
    class DoubleToPercent : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return 100 / (double)parameter * (double)value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
