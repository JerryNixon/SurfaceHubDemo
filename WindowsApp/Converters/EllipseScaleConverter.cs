using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace WindowsApp.Converters
{
    class EllipseScaleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var scale = (double)value;
            if (scale == 1)
                return 1d;
            else if (scale == 2)
                return 1.5d;
            else if (scale == 3)
                return 2d;
            else if (scale == 4)
                return 2.5d;
            else if (scale == 5)
                return 3d;
            else if (scale == 6)
                return 3.5d;
            else if (scale == 7)
                return 4d;
            else if (scale == 8)
                return 4.5d;
            else if (scale == 9)
                return 5d;
            else if (scale == 10)
                return 5.5d;
            return 1d;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
