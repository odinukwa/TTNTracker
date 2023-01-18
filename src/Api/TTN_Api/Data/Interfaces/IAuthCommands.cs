using System.Threading.Tasks;
using TTN_Tracker.Features.Dto;
using TTN_Tracker.MiddleWare;

namespace TTN_Tracker.Data
{
    public interface IAuthCommands
    {
        //Register User
        //Update User Profile
        //Login User
        Task<ApiResponse> RegisterUser(UserProfileCreateDto data);
        Task<ApiResponse> LoginUser(UserLoginDto data);
        Task<ApiResponse> UpdateUser(UserProfileUpdateDto data);
    }
}