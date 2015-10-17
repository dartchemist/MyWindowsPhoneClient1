using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsPhoneClient.UI.Models
{
    public class CoordinateModel
    {
        public double Longitude { get; set; }
        public double Latitude { get; set; }

        public CoordinateModel()
        {

        }
        
        public CoordinateModel(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}
