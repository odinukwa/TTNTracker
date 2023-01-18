using System.Collections.Generic;
using System.Threading.Tasks;
using TTN_Tracker.Features.Dto;
using TTN_Tracker.MiddleWare;

namespace TTN_Tracker.Data
{
    public interface IDeviceQueries
    {
        //Get User Profile
        Task<List<UserDeviceGetDto>> GetUserDevices(int userId);
        Task<UserDeviceSingleGetDto> GetUserDeviceSingleAsync(int userId, string devId);
        Task<DeviceQrCodeDto> GetDeviceQrcode(string devEui);
        Task<List<DeviceQrCodeDto>> GetDeviceQrcodeAllAsync();
        Task<List<DeviceDownlinkDto>> GetDeviceDownlinkAsync(int userId, string devId);
    }
}