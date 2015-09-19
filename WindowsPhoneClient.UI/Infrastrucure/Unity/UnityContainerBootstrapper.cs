using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using WindowsPhoneClient.ServiceConsumer;
using WindowsPhoneClient.UI.ViewServices;

namespace WindowsPhoneClient.UI.Infrastrucure.Unity
{
    public static class UnityContainerBootstrapper
    {
        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IGetPartnersInformationService, GetPartnersInformationService>();
            container.RegisterType<IMessageService, MessageService>();
        }
    }
}
