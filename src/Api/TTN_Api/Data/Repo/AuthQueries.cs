using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using TTN_DDOI.Model;
using TTN_Tracker.Features.Dto;
using TTN_Tracker.MiddleWare;

namespace TTN_Tracker.Data
{
    public class AuthQueries : IAuthQueries
    {
        private TTNTrackerDbContext _context;
        private readonly IMapper _mapper;
        private IDapperRepository _dapperContext;

        public AuthQueries(
        TTNTrackerDbContext context, IMapper mapper,
        IDapperRepository dapperContext)
        {
            _context = context;
            _mapper = mapper;
            _dapperContext = dapperContext;
        }


        public async Task<UserProfileGetDto> GetUserProfile(int userId)
        {
            UserProfileGetDto response = null;
            try
            {
                //var user = await _context.UserProfile.FindAsync(userId);
                // var user = await _context.UserProfile.Include(i => i.User).FirstOrDefaultAsync(i => i.Id == userId);
                // var mail = user.User.Email;

                var user = await _dapperContext.GetAsync<UserProfileGetDto>("isp_GetUserProfile", new { userId = userId }, CommandType.StoredProcedure);
                response = user; // _mapper.Map<UserProfileGetDto>(user);
            }
            catch (Exception ex)
            {
                Log.Error("Error Creating User: {@data}", ex.Message);

            }
            return response;
        }

    }
}
