using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;
using static CsgoTactics.ViewModels.InventoryPageViewModel;

namespace CsgoTactics.Converters
{
    class InventoryStateToBool : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if ((InventoryState)value == InventoryState.Loaded)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
