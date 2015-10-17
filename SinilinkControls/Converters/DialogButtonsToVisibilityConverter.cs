using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace SinilinkControls.Converters
{
    public class DialogButtonsToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var dialogButtons = (DialogBoxButtons) value;
            switch (dialogButtons)
            {
                case DialogBoxButtons.Ok:
                    return Visibility.Collapsed;
                case DialogBoxButtons.OkCancel:
                    return Visibility.Visible;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}