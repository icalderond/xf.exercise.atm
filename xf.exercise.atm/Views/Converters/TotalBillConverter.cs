using System;
using System.Globalization;
using Xamarin.Forms;
using xf.exercise.atm.Models;

namespace xf.exercise.atm.Views.Converters
{
    public class TotalBillConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return 0;
            var dollarsBill = (DollarsBill)value;
            return dollarsBill.Quantity * dollarsBill.Value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
