
using System.Collections.Generic;
using MediatR;
using TTN_Tracker.Features.Dto;

namespace TTN_Tracker.Queries
{
    public class GetUserDevicesQuery : IRequest<List<UserDeviceGetDto>>
    {
        public int Id { get; set; }
    }
}