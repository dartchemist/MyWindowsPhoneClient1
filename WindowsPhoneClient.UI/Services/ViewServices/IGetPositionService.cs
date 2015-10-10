using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsPhoneClient.UI.Models;

namespace WindowsPhoneClient.UI.Services.ViewServices
{
    public interface IGetPositionService
    {
        Task<CoordinateModel> GetCurrentPosition();
    }
}
