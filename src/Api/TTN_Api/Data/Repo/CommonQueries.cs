using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Serilog;
using TTN_Tracker.Features.Dto;

namespace TTN_Tracker.Data
{

    public class CommonQueries : ICommonQueries
    {
        // private TTNTrackerDbContext _context;
        // private readonly IMapper _mapper;
        private IDapperRepository _dapperContext;

        public CommonQueries(
        IDapperRepository dapperContext)
        {
            //_context = context;
            //_mapper = mapper;
            _dapperContext = dapperContext;
        }


        public async Task<List<ComboListDto>> GetFrequencyList()
        {
            List<ComboListDto> response = null;
            try
            {
                response = await _dapperContext.GetAllAsync<ComboListDto>("isp_GetFrequency", null, CommandType.StoredProcedure);
                // response = user; // _mapper.Map<UserProfileGetDto>(user);
            }
            catch (Exception ex)
            {
                Log.Error("Error Getting Freuencies: {@data}", ex.Message);

            }
            return response;
        }
        public async Task<List<ComboListDto>> GetLorawanVersionList()
        {
            List<ComboListDto> response = null;
            try
            {
                response = await _dapperContext.GetAllAsync<ComboListDto>("isp_GetLorawanVersion", null, CommandType.StoredProcedure);
                // response = user; // _mapper.Map<UserProfileGetDto>(user);
            }
            catch (Exception ex)
            {
                Log.Error("Error Getting Lorawan Version: {@data}", ex.Message);

            }
            return response;
        }


    }
}
