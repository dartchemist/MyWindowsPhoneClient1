﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsPhoneClient.UI.ViewServices
{
    public interface INavigationService
    {
        void Navigate(string pageUri);
        void GoBack();
    }
}
