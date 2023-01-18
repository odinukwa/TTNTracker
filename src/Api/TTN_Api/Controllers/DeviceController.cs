using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using TTN_Tracker.Features.Commands;
using TTN_Tracker.Features.Dto;
using TTN_Tracker.Queries;
using TTN_Tracker.Utility;

namespace TTN_Tracker.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/device")]
    public class DeviceController : ControllerBase
    {
        private readonly IMediator _mediator;
        private UserData _userData;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public DeviceController(IMediator mediator,
        ICookieUtil userDataCookie,
        IWebHostEnvironment environment)
        {
            _mediator = mediator;
            _userData = userDataCookie.GetUserData();
            _hostingEnvironment = environment;

        }

        [HttpPost]
        public async Task<ActionResult> CreateDevice(CreateUserDeviceCommand model)
        {
            model.UserId = _userData.UserId;

            Log.Information("Request: {@data}", model.ToString());
            var result = await _mediator.Send(model);
            return Ok(result);
        }

        [HttpGet]

        public async Task<ActionResult> Devices()
        {
            List<UserDeviceGetDto> result = null;
            try
            {
                GetUserDevicesQuery data = new GetUserDevicesQuery()
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

        [HttpGet("{devId}")]

        public async Task<ActionResult> Devices(string devId)
        {
            UserDeviceSingleGetDto result = null;
            try
            {
                GetUserDeviceSingleQuery data = new GetUserDeviceSingleQuery()
                {
                    userId = _userData.UserId,
                    devId = devId
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

        [HttpGet("Downlink/{devId}")]

        public async Task<ActionResult> DeviceDownlink(string devId)
        {
            List<DeviceDownlinkDto> result = null;
            try
            {
                GetDeviceDownlinksQuery data = new GetDeviceDownlinksQuery()
                {
                    UserId = _userData.UserId,
                    DevId = devId
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


        [HttpPost("generateqrcode")]
        public async Task<ActionResult> CreateDeviceQrcode(CreateDeviceQrCodeCommand model)
        {
            model.UserId = _userData.UserId;

            Log.Information("Request: {@data}", model.ToString());
            var result = await _mediator.Send(model);
            return Ok(result);
        }

        [HttpDelete("deleteqrcode/{devEui}")]
        public async Task<ActionResult> DeleteDeviceQrcode(string devEui)
        {
            DeleteDeviceQrCodeCommand model = new DeleteDeviceQrCodeCommand()
            {
                devEui = devEui
            };
            Log.Information("Request: {@data}", model.ToString());
            var result = await _mediator.Send(model);
            return Ok(result);
        }


        // [HttpPost("readqrcode")]

        // public async Task<ActionResult> ReadQrCode(IFormFile file)
        // {
        //     DeviceQrCodeDto result = null;
        //     try
        //     {
        //         if (file.Length > 0)
        //         {
        //             if (!Directory.Exists(_hostingEnvironment.ContentRootPath + "\\uploads\\"))
        //             {
        //                 Directory.CreateDirectory(_hostingEnvironment.ContentRootPath + "\\uploads\\");
        //             }
        //             string path = _hostingEnvironment.ContentRootPath + "\\uploads\\" + file.FileName;

        //             using (var stream = new FileStream(path, FileMode.Create))
        //             {
        //                 await file.CopyToAsync(stream);
        //             }
        //             GetDeviceQrcodeQuery data = new GetDeviceQrcodeQuery()
        //             {
        //                 qrCode = path
        //             };
        //             Log.Information("Request: {@data}", data.ToString());

        //             result = await _mediator.Send(data);
        //         }
        //         else
        //         {

        //         }

        //     }
        //     catch (Exception ex)
        //     {
        //         Log.Error("Error: {@data}", ex.Message);
        //     }
        //     if (result != null)
        //     {
        //         return Ok(result);
        //     }
        //     else
        //     {
        //         return NotFound();
        //     }

        // }

        [HttpGet("readqrcode")]
        public async Task<ActionResult> ReadQrCode(string devEui)
        {
            DeviceQrCodeDto result = null;
            try
            {
                GetDeviceQrcodeQuery data = new GetDeviceQrcodeQuery()
                {
                    devEui = devEui
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


        [HttpGet("qrcodes")]
        public async Task<ActionResult> ReadAllQrCode()
        {
            List<DeviceQrCodeDto> result = null;
            try
            {
                GetDeviceQrcodeAllQuery data = new GetDeviceQrcodeAllQuery()
                {
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