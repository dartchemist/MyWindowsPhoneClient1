using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsPhoneClient.UI.Infrastrucure;
using WindowsPhoneClient.UI.Services;

namespace WindowsPhoneClient.UI.ViewModels
{
    public abstract class BaseViewModel : BindingBase
    {
        private readonly IStorageService _storageService;

        protected IStorageService StorageService
        {
            get { return _storageService; }
        }
        
        protected BaseViewModel(IStorageService storageService)
        {
            _storageService = storageService;
        }
    }
}
