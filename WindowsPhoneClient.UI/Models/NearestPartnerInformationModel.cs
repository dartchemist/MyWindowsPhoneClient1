using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsPhoneClient.UI.Infrastrucure;

namespace WindowsPhoneClient.UI.Models
{
    public class NearestPartnerInformationModel : BindingBase
    {
        private int _branchKey;
        public int BranchKey
        {
            get { return _branchKey; }
            set { SetField<int>(ref _branchKey, value); }
        }

        private CoordinateModel _location;
        public CoordinateModel Location
        {
            get { return _location; }
            set { SetField<CoordinateModel>(ref _location, value); }
        }

        public NearestPartnerInformationModel(int branchKey, CoordinateModel location)
        {
            _branchKey = branchKey;
            _location = location;
        }
    }
}
