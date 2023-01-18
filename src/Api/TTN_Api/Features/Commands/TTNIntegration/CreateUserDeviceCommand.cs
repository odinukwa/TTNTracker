using MediatR;
using TTN_Tracker.Features.Dto;
using TTN_Tracker.MiddleWare;

namespace TTN_Tracker.Features.Commands
{
    public class CreateUserDeviceCommand : UserDeviceCreateDto, IRequest<ApiResponse>
    {

    }
}