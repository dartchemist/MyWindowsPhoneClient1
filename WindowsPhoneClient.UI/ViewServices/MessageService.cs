using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WindowsPhoneClient.UI.ViewServices
{
    public class MessageService : IMessageService
    {
        public bool ShowMessage(string message, string caption)
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
