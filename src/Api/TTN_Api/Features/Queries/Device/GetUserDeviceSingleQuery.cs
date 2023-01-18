
using System.Collections.Generic;
using MediatR;
using TTN_Tracker.Features.Dto;

namespace TTN_Tracker.Queries
{
    public class GetUserDeviceSingleQuery : IRequest<UserDeviceSingleGetDto>
    {
        public string devId { get; set; }
        public int userId { get; set; }
    }
}