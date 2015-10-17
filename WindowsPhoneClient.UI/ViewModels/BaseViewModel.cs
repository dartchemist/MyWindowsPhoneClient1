using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsPhoneClient.UI.Infrastrucure;
using WindowsPhoneClient.UI.Services;
using WindowsPhoneClient.UI.Services.ViewServices;

namespace WindowsPhoneClient.UI.ViewModels
{
    public abstract class BaseViewModel : BindingBase
    {
        private readonly IStorageService _storageService;
        private readonly INavigationService _navigationService;

        protected IStorageService StorageService
        {
            get { return _storageService; }
        }

        protected INavigationService NavigationService
        {
            get { return _navigationService; }
        }
        
        protected BaseViewModel(INavigationService navigationService, IStorageService storageService)
        {
            _storageService = storageService;
            _navigationService = navigationService;
        }
    }
}
