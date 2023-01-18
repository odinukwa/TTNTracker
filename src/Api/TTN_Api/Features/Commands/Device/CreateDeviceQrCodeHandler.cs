using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TPMMobileApi.MiddleWare;
using Serilog;
using TTN_DDOI.Model;
using TTN_Tracker.MiddleWare;
using TTN_Tracker.Data;

namespace TTN_Tracker.Features.Commands
{
    public class CreateDeviceQrCodeHandler : IRequestHandler<CreateDeviceQrCodeCommand, ApiResponse>
    {
        private readonly IMediator _mediator;
        //private readonly IMapper _mapper;
        private ITTNIntegrationCommands _repo;

        public CreateDeviceQrCodeHandler(IMediator mediator,
        ITTNIntegrationCommands repo
        )
        {
            _mediator = mediator;
            _repo = repo;
            // _fxRepo = fxRepo;
        }

        public async Task<ApiResponse> Handle(CreateDeviceQrCodeCommand request, CancellationToken cancellationToken)
        {
            Log.Information("Handler for Registering Device");
            ApiResponse response = await _repo.CreateDeviceQrCode(request);

            return response;
        }
    }


}