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
    public class DeleteDeviceQrCodeHandler : IRequestHandler<DeleteDeviceQrCodeCommand, ApiResponse>
    {
        private readonly IMediator _mediator;
        //private readonly IMapper _mapper;
        private ITTNIntegrationCommands _repo;

        public DeleteDeviceQrCodeHandler(IMediator mediator,
        ITTNIntegrationCommands repo
        )
        {
            _mediator = mediator;
            _repo = repo;
            // _fxRepo = fxRepo;
        }

        public async Task<ApiResponse> Handle(DeleteDeviceQrCodeCommand request, CancellationToken cancellationToken)
        {
            Log.Information("Handler for Deleting devices");
            ApiResponse response = await _repo.DeleteDeviceQrCode(request.devEui);

            return response;
        }
    }


}