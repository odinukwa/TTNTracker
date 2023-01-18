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
    public class CreateUserProfileHandler : IRequestHandler<CreateUserProfileCommand, ApiResponse>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private IAuthCommands _authRepo;

        public CreateUserProfileHandler(IMediator mediator, IMapper mapper,
        IAuthCommands authRepo
        )
        {
            _mediator = mediator;
            _mapper = mapper;
            _authRepo = authRepo;
        }

        public async Task<ApiResponse> Handle(CreateUserProfileCommand request, CancellationToken cancellationToken)
        {
            Log.Information("Starting Post Uplink Message");
            ApiResponse response = await _authRepo.RegisterUser(request);

            return response;
        }
    }


}