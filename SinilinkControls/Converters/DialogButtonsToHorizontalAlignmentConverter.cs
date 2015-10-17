using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace SinilinkControls.Converters
{
    public class DialogButtonsToHorizontalAlignmentConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var dialogButtons = (DialogBoxButtons) value;
            switch (dialogButtons)
            {
                case DialogBoxButtons.Ok:
                    return HorizontalAlignment.Center;
                case DialogBoxButtons.OkCancel:
                    return HorizontalAlignment.Left;
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}