
using MediatR;
using TTN_Tracker.Features.Dto;

namespace TTN_Tracker.Queries
{
    public class GetUserProfileByIdQuery : IRequest<UserProfileGetDto>
    {
        public int Id { get; set; }
    }
}