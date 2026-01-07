using Microsoft.UI.Xaml.Data;
using System;

namespace CDOWin.Converters;

class BoolTransparentConverter : IValueConverter {
    public object Convert(object value, Type targetType, object parameter, string language) {
        if (value is bool b) {
            return b == true ? 1.0 : 0.0;
        }

        return 1.0;
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language) {
        throw new NotImplementedException();
    }
}
