using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using WindowsPhoneClient.ServiceConsumer;
using WindowsPhoneClient.UI.Services;
using WindowsPhoneClient.UI.Services.ViewServices;

namespace WindowsPhoneClient.UI.Infrastrucure.Unity
{
    public static class UnityContainerBootstrapper
    {
        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IGetPartnersInformationService, GetPartnersInformationService>();
            container.RegisterType<IMessageService, DialogMessageService>();
            container.RegisterType<INavigationService, NavigationService>();
            container.RegisterType<IGetPositionService, GetPositionService>();
            container.RegisterType<IParkingAvailabilityService, ParkingAvailabilityService>();
            container.RegisterType<IStorageService, StorageService>(new ContainerControlledLifetimeManager());
        }
    }
}
