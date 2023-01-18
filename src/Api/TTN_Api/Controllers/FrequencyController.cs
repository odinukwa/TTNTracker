using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using TTN_Tracker.Features.Dto;
using TTN_Tracker.Queries;
using TTN_Tracker.Utility;

namespace TTN_Tracker.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/frequency")]
    public class FrequencyController : ControllerBase
    {
        private readonly IMediator _mediator;
        //private UserData _userData;

        public FrequencyController(IMediator mediator)
        {
            _mediator = mediator;
            //_userData = userDataCookie.GetUserData();

        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            List<ComboListDto> result = null;
            try
            {
                GetFrequencyQuery data = new GetFrequencyQuery();
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