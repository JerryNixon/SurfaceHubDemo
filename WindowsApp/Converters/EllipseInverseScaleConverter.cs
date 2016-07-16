using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace WindowsApp.Converters
{
    class EllipseInverseScaleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var converter = new EllipseScaleConverter();
            var converted = (double)converter.Convert(value, targetType, parameter, language);
            return 1 / converted;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
