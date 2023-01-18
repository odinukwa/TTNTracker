using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using TTN_DDOI.Model;
using TTN_Tracker.Features.Dto;
using TTN_Tracker.MiddleWare;

namespace TTN_Tracker.Data
{
    public class AuthCommands : IAuthCommands
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private TTNTrackerDbContext _context;
        private readonly ApplicationSettings _appSettings;

        public AuthCommands(UserManager<ApplicationUser> userManager,
        TTNTrackerDbContext context,
        IOptions<ApplicationSettings> appsettings)
        {
            _userManager = userManager;
            _context = context;
            _appSettings = appsettings.Value;
        }

        public async Task<ApiResponse> RegisterUser(UserProfileCreateDto data)
        {
            ApiResponse response = new ApiResponse();
            try
            {
                var appUser = new ApplicationUser()
                {
                    Email = data.Email,
                    UserName = data.Email,

                };
                var result = await _userManager.CreateAsync(appUser, data.Password);

                if (result.Succeeded)
                {
                    var userProf = new UserProfile()
                    {
                        LastName = data.LastName,
                        FirstName = data.LastName,
                        DateCreated = DateTime.UtcNow.ToCentralTime(),
                        User = appUser,

                    };
                    _context.UserProfile.Add(userProf);
                    var rest = await _context.SaveChangesAsync();
                    if (rest > 0)
                    {
                        //user created successfully
                        response.status = true;
                        response.code = 0;
                        response.message = $"User Created Successfully";
                    }
                    else
                    {
                        await _userManager.DeleteAsync(appUser);
                        response.status = false;
                        response.code = 1;
                        response.message = $"Unable to create User";
                    }
                }
                else
                {
                    response.status = result.Succeeded;
                    response.code = 1;
                    response.message = $"Unable to create User";
                    response.data = result;
                }


            }
            catch (Exception ex)
            {
                Log.Error("Error Creating User: {@data}", ex.Message);
                response.code = 2;
                response.message = $"Error Creating User";
            }
            return response;
        }
        public async Task<ApiResponse> LoginUser(UserLoginDto data)
        {
            ApiResponse response = new ApiResponse();
            var user = await _userManager.FindByNameAsync(data.Email);
            if (user != null && await _userManager.CheckPasswordAsync(user, data.Password))
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.JWT_Secret));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var userClaim = new List<Claim>();

                userClaim.Add(new Claim("UserId", user.Id.ToString()));
                userClaim.Add(new Claim("Email", user.Email));

                var tokenOptions = new JwtSecurityToken(
                    claims: userClaim,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: signinCredentials
                );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);


                // var tokenDescriptor = new SecurityTokenDescriptor
                // {
                //     Subject = new ClaimsIdentity(new Claim[]
                //     {
                //         new Claim("UserId", user.Id.ToString())
                //     }),
                //     Expires = DateTime.Now.AddMinutes(5),
                //     SigningCredentials = signinCredentials
                // };

                // var tokenHandler = new JwtSecurityTokenHandler();
                // var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                // var tokenString = new JwtSecurityTokenHandler().WriteToken(securityToken);
                response.status = true;
                response.code = 0;
                response.message = $"Success";
                response.data = new { token = tokenString };
                return response;
            }
            else
            {
                response.status = false;
                response.code = 1;
                response.message = $"Email or Password is Incorrect";
            }

            return response;
        }

        public async Task<ApiResponse> UpdateUser(UserProfileUpdateDto data)
        {
            ApiResponse response = new ApiResponse();
            try
            {
                var user = await _context.UserProfile.FindAsync(data.Id);
                if (user != null)
                {
                    user.LastName = data.LastName;
                    user.FirstName = data.LastName;
                    await _context.SaveChangesAsync();
                    response.status = true;
                    response.code = 0;
                    response.message = $"User Updated Successfully";
                    response.data = user;
                }
                else
                {
                    response.status = false;
                    response.code = 1;
                    response.message = $"User Not Found";
                }
            }
            catch (Exception ex)
            {
                Log.Error("Error Creating User: {@data}", ex.Message);
                response.code = 2;
                response.message = $"Error Updating User";
            }
            return response;
        }

    }
}
