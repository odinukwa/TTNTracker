using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using TTN_Tracker.Features.Dto;
using TTN_Tracker.Data;
using System.Collections.Generic;

namespace TTN_Tracker.Queries
{
    public class GetDeviceQrcodeHandler : IRequestHandler<GetDeviceQrcodeQuery, DeviceQrCodeDto>
    {
        private readonly IMediator _mediator;
        private IDeviceQueries _qryRepo;

        public GetDeviceQrcodeHandler(IMediator mediator, IDeviceQueries qryRepo)
        {
            _mediator = mediator;
            _qryRepo = qryRepo;

        }

        public async Task<DeviceQrCodeDto> Handle(GetDeviceQrcodeQuery request, CancellationToken cancellationToken)
        {
            var qryResponse = await _qryRepo.GetDeviceQrcode(request.devEui);

            return qryResponse; //_mapper.Map<AchOffsetAccountReadDto>(qryResponse);

        }
    }


}