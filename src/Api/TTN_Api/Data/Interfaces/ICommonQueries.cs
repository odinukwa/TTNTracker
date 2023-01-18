using System.Collections.Generic;
using System.Threading.Tasks;
using TTN_Tracker.Features.Dto;
using TTN_Tracker.MiddleWare;

namespace TTN_Tracker.Data
{
    public interface ICommonQueries
    {
        //Get User Profile
        Task<List<ComboListDto>> GetFrequencyList();
        Task<List<ComboListDto>> GetLorawanVersionList();
    }
}