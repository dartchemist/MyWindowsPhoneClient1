﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsPhoneClient.UI.Services
{
    public class StorageService : IStorageService
    {
        private readonly Dictionary<string, object> _resources = new Dictionary<string,object>();
        
        public void AddItem(string key, object item)
        {
            if (_resources.ContainsKey(key))
            {
                return;
            }
            _resources.Add(key, item);
        }

        public object GetItem(string key)
        {
            return _resources[key];
        }
    }
}
