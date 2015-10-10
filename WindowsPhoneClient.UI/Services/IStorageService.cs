using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsPhoneClient.UI.Services
{
    public interface IStorageService
    {
        void AddItem(string key, object item);
        object GetItem(string key);
    }
}
