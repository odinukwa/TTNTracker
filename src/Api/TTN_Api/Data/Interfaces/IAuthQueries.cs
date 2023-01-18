using System.Threading.Tasks;
using TTN_Tracker.Features.Dto;
using TTN_Tracker.MiddleWare;

namespace TTN_Tracker.Data
{
    public interface IAuthQueries
    {
        //Get User Profile
        Task<UserProfileGetDto> GetUserProfile(int userId);
    }
}