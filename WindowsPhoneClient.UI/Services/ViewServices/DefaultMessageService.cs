﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
//using WindowsPhoneClientUI.Services.ViewServices;

namespace WindowsPhoneClient.UI.Services.ViewServices
{
    public class DefaultMessageService : IMessageService
    {
        public bool ShowMessage(string message, string caption, bool confirmation)
        {
            var dialogResult = MessageBox.Show(message, caption, MessageBoxButton.OK);
            if (dialogResult == MessageBoxResult.OK || dialogResult == MessageBoxResult.Yes)
            {
                return true;
            }
            return false;
        }
    }
}
