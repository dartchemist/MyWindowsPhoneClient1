using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsPhoneClient.ServiceConsumer.BusinessModels
{
    public class Partner
    {
        public int PrimaryKey { get; set; }
        public string Model { get; set; }
        public string Name { get; set; }
        public int BranchKey { get; set; }
        public string VideoUrl { get; set; }
        public string LogoRelativePath { get; set; }
        public byte[] Logo { get; set; }
        public string MarkerImage { get; set; }
        public ICollection<string> Thumbnails { get; set; }
        public ICollection<string> AdvertismentImages { get; set; }

    }
}
