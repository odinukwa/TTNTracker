using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using TTN_Tracker.Features.Dto;
using TTN_Tracker.Data;
using System.Collections.Generic;

namespace TTN_Tracker.Queries
{
    public class GetUserDeviceSingleHandler : IRequestHandler<GetUserDeviceSingleQuery, UserDeviceSingleGetDto>
    {
        private readonly IMediator _mediator;
        private IDeviceQueries _qryRepo;

        public GetUserDeviceSingleHandler(IMediator mediator, IDeviceQueries qryRepo)
        {
            _mediator = mediator;
            _qryRepo = qryRepo;

        }

        public async Task<UserDeviceSingleGetDto> Handle(GetUserDeviceSingleQuery request, CancellationToken cancellationToken)
        {
            var qryResponse = await _qryRepo.GetUserDeviceSingleAsync(request.userId, request.devId);

            return qryResponse; //_mapper.Map<AchOffsetAccountReadDto>(qryResponse);

        }
    }


}