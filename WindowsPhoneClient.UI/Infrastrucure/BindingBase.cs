using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WindowsPhoneClient.UI.Services.ViewServices;

namespace WindowsPhoneClient.UI.Infrastrucure
{
    public abstract class BindingBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        
        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            Deployment.Current.Dispatcher.BeginInvoke(() =>
                {
                    if (handler == null)
                        return;

                    handler(this, new PropertyChangedEventArgs(propertyName));
                });
        }

        protected bool SetField<T>(ref T field, T value, [CallerMemberName]string propertyName =  null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return false;

            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
