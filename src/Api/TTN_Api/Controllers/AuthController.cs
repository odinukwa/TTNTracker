using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Serilog;
using TTN_Tracker.Features.Commands;
using TTN_Tracker.Features.Dto;
using TTN_Tracker.MiddleWare;
using TTN_Tracker.Queries;
using TTN_Tracker.Utility;

namespace TTN_Tracker.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;
        private UserData _userData;

        public AuthController(IMediator mediator, ICookieUtil userDataCookie)
        {
            _mediator = mediator;
            _userData = userDataCookie.GetUserData();


        }
        [HttpPost("register")]
        public async Task<ActionResult> Register(CreateUserProfileCommand data)
        {
            ApiResponse result = null;
            try
            {
                Log.Information("Request: {@data}", data.ToString());

                result = await _mediator.Send(data);

            }
            catch (Exception ex)
            {
                Log.Error("Error: {@data}", ex.Message);
            }
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(UserLoginCommand data)
        {
            ApiResponse result = null;
            try
            {
                Log.Information("Request: {@data}", data.ToString());

                result = await _mediator.Send(data);

            }
            catch (Exception ex)
            {
                Log.Error("Error: {@data}", ex.Message);
            }
            return Ok(result);
        }

        [Authorize]
        [HttpPost("UpdateUser")]
        public async Task<ActionResult> Update(UpdateUserProfileCommand data)
        {
            ApiResponse result = null;
            try
            {
                int userId = int.Parse(User.Claims.First(d => d.Type == "UserId").Value);
                data.Id = userId;
                Log.Information("Request: {@data}", data.ToString());

                result = await _mediator.Send(data);

            }
            catch (Exception ex)
            {
                Log.Error("Error: {@data}", ex.Message);
            }
            return Ok(result);
        }


        [HttpGet("UserProfile")]
        [Authorize]
        public async Task<ActionResult> UserProfile()
        {
            UserProfileGetDto result = null;
            try
            {
                // var claim = User.Claims;
                // int userId = int.Parse(User.Claims.First(d => d.Type == "UserId").Value);

                GetUserProfileByIdQuery data = new GetUserProfileByIdQuery()
                {
                    Id = _userData.UserId
                };
                Log.Information("Request: {@data}", data.ToString());

                result = await _mediator.Send(data);

            }
            catch (Exception ex)
            {
                Log.Error("Error: {@data}", ex.Message);
            }
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }

        }
    }
}