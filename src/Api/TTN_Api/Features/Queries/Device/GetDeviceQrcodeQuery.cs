
using System.Collections.Generic;
using MediatR;
using TTN_Tracker.Features.Dto;

namespace TTN_Tracker.Queries
{
    public class GetDeviceQrcodeQuery : IRequest<DeviceQrCodeDto>
    {
        public string devEui { get; set; }
    }
}