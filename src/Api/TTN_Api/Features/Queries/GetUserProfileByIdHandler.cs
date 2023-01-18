using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using TTN_Tracker.Features.Dto;
using TTN_Tracker.Data;

namespace TTN_Tracker.Queries
{
    public class GetUserProfileFromTokenHandler : IRequestHandler<GetUserProfileByIdQuery, UserProfileGetDto>
    {
        private readonly IMediator _mediator;
        private IAuthQueries _authQryRepo;

        public GetUserProfileFromTokenHandler(IMediator mediator, IAuthQueries authQryRepo)
        {
            _mediator = mediator;
            _authQryRepo = authQryRepo;

        }

        public async Task<UserProfileGetDto> Handle(GetUserProfileByIdQuery request, CancellationToken cancellationToken)
        {
            var qryResponse = await _authQryRepo.GetUserProfile(request.Id);

            return qryResponse; //_mapper.Map<AchOffsetAccountReadDto>(qryResponse);

        }
    }


}