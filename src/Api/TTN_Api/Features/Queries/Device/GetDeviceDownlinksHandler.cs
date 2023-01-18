using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using TTN_Tracker.Features.Dto;
using TTN_Tracker.Data;
using System.Collections.Generic;

namespace TTN_Tracker.Queries
{
    public class GetDeviceDownlinksHandler : IRequestHandler<GetDeviceDownlinksQuery, List<DeviceDownlinkDto>>
    {
        private readonly IMediator _mediator;
        private IDeviceQueries _qryRepo;

        public GetDeviceDownlinksHandler(IMediator mediator, IDeviceQueries qryRepo)
        {
            _mediator = mediator;
            _qryRepo = qryRepo;

        }

        public async Task<List<DeviceDownlinkDto>> Handle(GetDeviceDownlinksQuery request, CancellationToken cancellationToken)
        {
            var qryResponse = await _qryRepo.GetDeviceDownlinkAsync(request.UserId, request.DevId);

            return qryResponse; //_mapper.Map<AchOffsetAccountReadDto>(qryResponse);

        }
    }


}