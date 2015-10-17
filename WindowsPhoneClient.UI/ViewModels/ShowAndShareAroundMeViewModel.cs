using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using WindowsPhoneClient.CommonConstants;
using WindowsPhoneClient.ServiceConsumer;
using WindowsPhoneClient.ServiceConsumer.BusinessModels;
using WindowsPhoneClient.UI.Infrastrucure;
using WindowsPhoneClient.UI.Infrastrucure.Commands;
using WindowsPhoneClient.UI.Models;
using WindowsPhoneClient.UI.Services;
using WindowsPhoneClient.UI.Services.ViewServices;

namespace WindowsPhoneClient.UI.ViewModels
{
    public class ShowAndShareAroundMeViewModel : BaseViewModel
    {
        private readonly IParkingAvailabilityService _getParkingAvailabilityService;
        private readonly IGetPositionService _getPositionService;
        
        private readonly ObservableCollection<MapItemModel> _mapItems = new ObservableCollection<MapItemModel>();
        public ObservableCollection<MapItemModel> MapItems
        {
            get { return _mapItems; }
        }

        private CoordinateModel _currentUserLocation;
        public CoordinateModel CurrentUserLocation
        {
            get { return _currentUserLocation; }
            set { SetField<CoordinateModel>(ref _currentUserLocation, value); }
        }

        private CoordinateModel _currentMapPosition;
        public CoordinateModel CurrentMapPosition
        {
            get { return _currentMapPosition; }
            set 
            {
                SetField<CoordinateModel>(ref _currentMapPosition, value);
                MapItems.Clear();
                var nearestPartnerInformation = GetNearestPartnerInformation(_currentMapPosition)
                    .ContinueWith(t =>
                        {
                            Deployment.Current.Dispatcher.BeginInvoke(() =>
                                {
                                    AddMapItems(t.Result);
                                });
                            
                        }, TaskContinuationOptions.OnlyOnRanToCompletion);//Add Faulted case
            }
        }

        private double _availableParkingSpace;
        public double AvailableParkingSpace
        {
            get { return _availableParkingSpace; }
            set { SetField<double>(ref _availableParkingSpace, value); }
        }

        private bool _canUpdateMapContent;
        public bool CanUpdateMapContent
        {
            get { return _canUpdateMapContent; }
            set { SetField<bool>(ref _canUpdateMapContent, value); }
        }

        public ShowAndShareAroundMeViewModel(INavigationService navigationService, IStorageService storageService, IParkingAvailabilityService getParkingAvailabilityService, IGetPositionService getPositionService)
            : base(navigationService, storageService)
        {
            _getPositionService = getPositionService;
            _getParkingAvailabilityService = getParkingAvailabilityService;
            
            AvailableParkingSpace = 50;
        }

        public async Task GetCurrentUserPosition()
        {
            var currentUserLocation = await _getPositionService.GetCurrentPosition();
            
            CurrentUserLocation = currentUserLocation;
            var nearestPartnerInformation = await GetNearestPartnerInformation(currentUserLocation);
            AddMapItems(nearestPartnerInformation);
        }

        private async Task<IEnumerable<NearestPartnerInformationModel>> GetNearestPartnerInformation(CoordinateModel location)
        {
            var mappedNearestPartnerInformation = new List<NearestPartnerInformationModel>();
            var nearestPartnerInformation = await _getParkingAvailabilityService.GetParkingAvailability(location.Latitude, location.Longitude);

            foreach (var nearestPartner in nearestPartnerInformation)
            {
                mappedNearestPartnerInformation.Add(AutoMapper.Mapper.Map<NearestPartnerInformation, NearestPartnerInformationModel>(nearestPartner));
            }

            return mappedNearestPartnerInformation;
        }

        private void AddMapItems(IEnumerable<NearestPartnerInformationModel> nearestPartnerInformation)
        {
            var partnersInformation = StorageService.GetItem(ApplicationCommonConstants.PartnersInformationStorageKey) as IEnumerable<PartnerModel>;
            foreach (var nearestPartner in nearestPartnerInformation)
            {
                var currentMarkerImage = partnersInformation.Where(pm => pm.BranchKey == nearestPartner.BranchKey)
                    .First().MarkerImage;
                MapItems.Add(new MapItemModel
                {
                    Coordinate = nearestPartner.Location,
                    Marker = new MapMarkerModel
                    {
                        MarkerImage = currentMarkerImage
                    }
                });
            }
        }
    }
}
