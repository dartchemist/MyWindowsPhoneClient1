using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsPhoneClient.UI.Services
{
    public class StorageService : IStorageService
    {
        private readonly Dictionary<string, object> _resources;
        
        public void AddItem(string key, object item)
        {
            _resources.Add(key, item);
        }

        public object GetItem(string key)
        {
            return _resources[key];
        }
    }
}
