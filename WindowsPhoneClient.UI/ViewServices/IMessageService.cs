using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsPhoneClient.UI.ViewServices
{
    public interface IMessageService
    {
        bool ShowMessage(string message, string caption);
    }
}
