﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsPhoneClient.UI.Infrastrucure;

namespace WindowsPhoneClient.UI.Models
{
    public class PartnerModel : BindingBase
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetField<string>(ref _name, value); }
        }

        private string _logoRelativePath;
        public string LogoRelativePath
        {
            get { return _logoRelativePath; }
            set { SetField<string>(ref _logoRelativePath, value); }
        }

        private byte[] _logo;
        public byte[] Logo
        {
            get { return _logo; }
            set { SetField<byte[]>(ref _logo, value); }
        }

        private string _markerImage;
        public string MarkerImage
        {
            get { return _markerImage; }
            set { SetField<string>(ref _markerImage, value); }
        }
    }
}
