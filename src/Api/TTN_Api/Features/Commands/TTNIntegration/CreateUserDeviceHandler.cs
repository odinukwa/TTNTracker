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
    public class CreateUserDeviceHandler : IRequestHandler<CreateUserDeviceCommand, ApiResponse>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private ITTNIntegrationCommands _ttnRepo;

        public CreateUserDeviceHandler(IMediator mediator, IMapper mapper,
        ITTNIntegrationCommands ttnRepo
        )
        {
            _mediator = mediator;
            _mapper = mapper;
            _ttnRepo = ttnRepo;
            // _fxRepo = fxRepo;
        }

        public async Task<ApiResponse> Handle(CreateUserDeviceCommand request, CancellationToken cancellationToken)
        {
            Log.Information("Handler for Registering Device");
            ApiResponse response = await _ttnRepo.RegisterUserDevice(request);

            return response;
        }
    }


}