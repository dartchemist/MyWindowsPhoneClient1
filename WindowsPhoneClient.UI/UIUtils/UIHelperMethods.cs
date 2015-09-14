using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WindowsPhoneClient.UI.UIUtils
{
    public static class UIHelperMethods
    {
        public static double GetScreenWidth()
        {
            return Application.Current.Host.Content.ActualWidth;
        }

        public static double GetScreenHeight()
        {
            return Application.Current.Host.Content.ActualHeight;
        }
    }
}
