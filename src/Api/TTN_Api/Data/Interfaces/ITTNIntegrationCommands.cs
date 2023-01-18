
using System.Threading.Tasks;
using TTN_Tracker.Features.Dto;
using TTN_Tracker.MiddleWare;

namespace TTN_Tracker.Data
{
    public interface ITTNIntegrationCommands
    {
        //post uplink message
        //create devices
        //update devices
        Task<ApiResponse> PostUplinkMessage(UplinkMessageCreateDto data);
        Task<ApiResponse> RegisterUserDevice(UserDeviceCreateDto data);
        Task<ApiResponse> CreateDeviceQrCode(DeviceQrCodeDto data);
        Task<ApiResponse> DeleteDeviceQrCode(string devEui);
    }
}