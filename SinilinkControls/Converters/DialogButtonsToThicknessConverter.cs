using System.Windows;
using System.Windows.Data;

namespace SinilinkControls.Converters
{
    public class DialogButtonsToThicknessConverter : IValueConverter
    {
        private const double ThicknessOffset = 30.0;
        private const double BottomThicknessOffset = 10.0;
        
        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var dialogButtons = (DialogBoxButtons) value;
            switch (dialogButtons)
            {
                case DialogBoxButtons.Ok:
                    return new Thickness(0.0, 0.0, 0.0, BottomThicknessOffset);
                case DialogBoxButtons.OkCancel:
                    var parameterValue = (string)parameter;
                    switch (parameterValue)
                    {
                        case "Ok":
                            return new Thickness(ThicknessOffset, 0.0, 0.0, BottomThicknessOffset);
                        case "Cancel":
                            return new Thickness(0.0, 0.0, ThicknessOffset, BottomThicknessOffset);
                    }
                    break;
            }
            
            return null;
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new System.NotImplementedException();
        }
    }
}