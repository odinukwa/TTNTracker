using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using TTN_Tracker.Features.Dto;
using TTN_Tracker.Data;
using System.Collections.Generic;

namespace TTN_Tracker.Queries
{
    public class GetDeviceQrcodeAllHandler : IRequestHandler<GetDeviceQrcodeAllQuery, List<DeviceQrCodeDto>>
    {
        private readonly IMediator _mediator;
        private IDeviceQueries _qryRepo;

        public GetDeviceQrcodeAllHandler(IMediator mediator, IDeviceQueries qryRepo)
        {
            _mediator = mediator;
            _qryRepo = qryRepo;

        }

        public async Task<List<DeviceQrCodeDto>> Handle(GetDeviceQrcodeAllQuery request, CancellationToken cancellationToken)
        {
            var qryResponse = await _qryRepo.GetDeviceQrcodeAllAsync();

            return qryResponse; //_mapper.Map<AchOffsetAccountReadDto>(qryResponse);

        }
    }


}