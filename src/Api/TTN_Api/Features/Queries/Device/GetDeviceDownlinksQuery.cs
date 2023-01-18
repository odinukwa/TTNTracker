
using System.Collections.Generic;
using MediatR;
using TTN_Tracker.Features.Dto;

namespace TTN_Tracker.Queries
{
    public class GetDeviceDownlinksQuery : IRequest<List<DeviceDownlinkDto>>
    {
        public int UserId { get; set; }
        public string DevId { get; set; }
    }
}