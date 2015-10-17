using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsPhoneClient.UI.Infrastrucure;

namespace WindowsPhoneClient.UI.Models
{
    public class PartnerModel : BindingBase
    {
        private int _branchKey;
        public int BranchKey
        {
            get { return _branchKey; }
            set { SetField<int>(ref _branchKey, value); }
        }
        
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

        private string _markerImageRelativePath;
        public string MarkerImageRelativePath
        {
            get { return _markerImageRelativePath; }
            set { SetField<string>(ref _markerImageRelativePath, value); }
        }

        private byte[] _markerImage;
        public byte[] MarkerImage
        {
            get { return _markerImage; }
            set { SetField<byte[]>(ref _markerImage, value); }
        }
    }
}
