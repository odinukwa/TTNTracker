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
using ZXing;
using System.Drawing.Imaging;
using System.Drawing;

namespace TTN_Tracker.Data
{

    public class DeviceQueries : IDeviceQueries
    {
        // private TTNTrackerDbContext _context;
        // private readonly IMapper _mapper;
        private IDapperRepository _dapperContext;

        public DeviceQueries(
        IDapperRepository dapperContext)
        {
            //_context = context;
            //_mapper = mapper;
            _dapperContext = dapperContext;
        }


        public async Task<List<UserDeviceGetDto>> GetUserDevices(int userId)
        {
            List<UserDeviceGetDto> response = null;
            try
            {
                response = await _dapperContext.GetAllAsync<UserDeviceGetDto>("isp_GetDevices", new { userId = userId }, CommandType.StoredProcedure);
                // response = user; // _mapper.Map<UserProfileGetDto>(user);
            }
            catch (Exception ex)
            {
                Log.Error("Error Getting User Devices: {@data}", ex.Message);

            }
            return response;
        }

        public async Task<UserDeviceSingleGetDto> GetUserDeviceSingleAsync(int userId, string devId)
        {
            UserDeviceSingleGetDto response = null;
            try
            {
                response = await _dapperContext.GetAsync<UserDeviceSingleGetDto>("isp_GetDevicesById", new { userId = userId, devId }, CommandType.StoredProcedure);
                // response = user; // _mapper.Map<UserProfileGetDto>(user);
            }
            catch (Exception ex)
            {
                Log.Error("Error Getting User Devices: {@data}", ex.Message);

            }
            return response;
        }
        public async Task<DeviceQrCodeDto> GetDeviceQrcode(string devEui)
        {
            DeviceQrCodeDto response = null;
            try
            {
                // string devEui = "";
                // var reader = new BarcodeReader();
                // var result = reader.Decode(new Bitmap(qrCodeFile));
                // if (result != null)
                // {
                //     devEui = result.Text;
                // }
                response = await _dapperContext.GetAsync<DeviceQrCodeDto>("isp_GetDeviceQrCode", new { devEui = devEui, isAll = false }, CommandType.StoredProcedure);
                // response = user; // _mapper.Map<UserProfileGetDto>(user);
            }
            catch (Exception ex)
            {
                Log.Error("Error Getting Device QrCode: {@data}", ex.Message);

            }
            return response;
        }
        public async Task<List<DeviceQrCodeDto>> GetDeviceQrcodeAllAsync()
        {
            List<DeviceQrCodeDto> response = null;
            try
            {
                response = await _dapperContext.GetAllAsync<DeviceQrCodeDto>("isp_GetDeviceQrCode", new { devEui = "", isAll = true }, CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                Log.Error("Error Getting Device QrCode: {@data}", ex.Message);

            }
            return response;
        }

        public async Task<List<DeviceDownlinkDto>> GetDeviceDownlinkAsync(int userId, string devId)
        {
            List<DeviceDownlinkDto> response = null;
            try
            {
                response = await _dapperContext.GetAllAsync<DeviceDownlinkDto>("isp_GetDownlink", new { userId, devId }, CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                Log.Error("Error Getting Device QrCode: {@data}", ex.Message);

            }
            return response;
        }


    }
}
