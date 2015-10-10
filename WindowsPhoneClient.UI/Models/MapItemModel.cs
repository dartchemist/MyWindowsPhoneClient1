using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsPhoneClient.UI.Infrastrucure;

namespace WindowsPhoneClient.UI.Models
{
    public class MapItemModel
    {
        public CoordinateModel Coordinate { get; set; }

        public MapMarkerModel Marker { get; set; }
    }
}
