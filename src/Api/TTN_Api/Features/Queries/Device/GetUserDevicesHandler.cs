using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using TTN_Tracker.Features.Dto;
using TTN_Tracker.Data;
using System.Collections.Generic;

namespace TTN_Tracker.Queries
{
    public class GetUserDevicesHandler : IRequestHandler<GetUserDevicesQuery, List<UserDeviceGetDto>>
    {
        private readonly IMediator _mediator;
        private IDeviceQueries _qryRepo;

        public GetUserDevicesHandler(IMediator mediator, IDeviceQueries qryRepo)
        {
            _mediator = mediator;
            _qryRepo = qryRepo;

        }

        public async Task<List<UserDeviceGetDto>> Handle(GetUserDevicesQuery request, CancellationToken cancellationToken)
        {
            var qryResponse = await _qryRepo.GetUserDevices(request.Id);

            return qryResponse; //_mapper.Map<AchOffsetAccountReadDto>(qryResponse);

        }
    }


}