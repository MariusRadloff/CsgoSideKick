using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace CsgoTactics.Converters
{
    class BoolToSymbolIcon : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if ((bool)value == true)
            {
                return Windows.UI.Xaml.Controls.Symbol.Remove;
            }
            else
            {
                return Windows.UI.Xaml.Controls.Symbol.Add;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
