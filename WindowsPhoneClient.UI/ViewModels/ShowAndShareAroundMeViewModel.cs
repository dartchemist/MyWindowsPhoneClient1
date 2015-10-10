using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using WindowsPhoneClient.ServiceConsumer;
using WindowsPhoneClient.UI.Infrastrucure;
using WindowsPhoneClient.UI.Models;
using WindowsPhoneClient.UI.Services;
using WindowsPhoneClient.UI.Services.ViewServices;

namespace WindowsPhoneClient.UI.ViewModels
{
    public class ShowAndShareAroundMeViewModel : BaseViewModel
    {
        private readonly IGetParkingAvailabilityService _getParkingAvailabilityService;
        
        private readonly ObservableCollection<MapItemModel> _mapItems = new ObservableCollection<MapItemModel>();
        public ObservableCollection<MapItemModel> MapItems
        {
            get { return _mapItems; }
        }
        
        private CoordinateModel _currentLocation;
        public CoordinateModel CurrentLocation
        {
            get { return _currentLocation; }
            set { SetField<CoordinateModel>(ref _currentLocation, value); }
        }

        private bool _canUpdateMapContent;
        public bool CanUpdateMapContent
        {
            get { return _canUpdateMapContent; }
            set { SetField<bool>(ref _canUpdateMapContent, value); }
        }

        public ShowAndShareAroundMeViewModel(IStorageService storageService, IGetParkingAvailabilityService getParkingAvailabilityService, IGetPositionService getPositionService)
            :base(storageService)
        {
            _getParkingAvailabilityService = getParkingAvailabilityService;
            
            //Add faulted taks case
            getPositionService.GetCurrentPosition().ContinueWith(t =>
            {
                CurrentLocation = t.Result;
                //_getParkingAvailabilityService.GetParkingAvailabilityAroundMe(CurrentCoordinates.Latitude, CurrentCoordinates.Longitude);
            }, TaskContinuationOptions.OnlyOnRanToCompletion);
        }
    }
}
