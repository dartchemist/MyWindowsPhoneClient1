using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace WindowsPhoneClient.UI.UserControls
{
    public partial class SinilinkMenu : UserControl
    {
        public static  readonly  DependencyProperty IsOpenProperty =
            DependencyProperty.Register("IsOpen", typeof(bool), typeof(SinilinkMenu), new PropertyMetadata(false));

        public bool IsOpen
        {
            get { return (bool) GetValue(IsOpenProperty); }
            set { SetValue(IsOpenProperty, value); }
        }
        
        public SinilinkMenu()
        {
            InitializeComponent();
        }
    }
}
