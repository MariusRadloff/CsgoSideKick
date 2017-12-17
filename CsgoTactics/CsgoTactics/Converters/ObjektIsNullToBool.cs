using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace CsgoTactics.Converters
{
    class ObjektIsNullToBool : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value != null)
            {
                if (targetType == typeof(Windows.UI.Xaml.Visibility))
                {
                    return Windows.UI.Xaml.Visibility.Visible;
                }
                return true;
            }
            else
            {
                if (targetType == typeof(Windows.UI.Xaml.Visibility))
                {
                    return Windows.UI.Xaml.Visibility.Collapsed;
                }
                return false;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
