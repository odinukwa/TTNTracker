using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Serilog;
using TTN_Tracker.Features.Dto;
using TTN_Tracker.MiddleWare;

namespace TTN_Tracker.Data.Http
{
    public class TTNCustomClient : ITTNCustomClient
    {
        public HttpClient _httpClient
        {
            get;
            set;
        }
        private readonly JsonSerializerOptions _options;
        private readonly ApplicationSettings _appsettings;

        public TTNCustomClient(HttpClient httpClient,
        IOptions<ApplicationSettings> appsettings)
        {
            _appsettings = appsettings.Value;
            httpClient.BaseAddress = new Uri("https://eu1.cloud.thethings.network/api/v3/");
            httpClient.DefaultRequestHeaders.Clear();
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _appsettings.TTN_App_Key);

            //httpClient.DefaultRequestHeaders.Add("User-Agent", "HttpClientFactory-Sample");

            _httpClient = httpClient;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task<object> GetDevice(string devId)
        {
            var uri = $"applications/ttn-ddoit-test/devices/grp1-dev1?field_mask=name,description,version_ids,network_server_address,application_server_address,join_server_address,locations,attributes";
            using (var response = await _httpClient.GetAsync(uri, HttpCompletionOption.ResponseHeadersRead))
            {
                response.EnsureSuccessStatusCode();
                var stream = await response.Content.ReadAsStreamAsync();
                var device = await JsonSerializer.DeserializeAsync<object>(stream, _options);
                return device;

            }
        }


        public async Task<ApiResponse> CreateDeviceAsync(Features.Dto.EndDeviceRegistry.EndDeviceDto endDeviceDto)
        {
            ApiResponse resp = new ApiResponse();
            Features.Dto.EndDeviceRegistry.End_Device device = null;
            try
            {
                var endDeviceJson = new StringContent(
                    JsonSerializer.Serialize(endDeviceDto, _options),
                    Encoding.UTF8,
                    "application/json");

                using var httpResponse =
                    await _httpClient.PostAsync("applications/ttn-ddoit-test/devices", endDeviceJson);

                if (httpResponse.IsSuccessStatusCode)
                {
                    var stream = await httpResponse.Content.ReadAsStreamAsync();
                    device = await JsonSerializer.DeserializeAsync<Features.Dto.EndDeviceRegistry.End_Device>(stream, _options);
                    resp.code = 0;
                    resp.message = "Success";
                    resp.status = true;
                    resp.data = device;
                }
                else
                {
                    var stream = await httpResponse.Content.ReadAsStreamAsync();
                    var res = await JsonSerializer.DeserializeAsync<Errorobject>(stream, _options);
                    resp.code = res != null ? res.code : 1;
                    resp.message = res != null ? res.message : "Failure creating device on TTN";
                    resp.status = false;
                    Log.Information("Error Creating Device on TTN: {@data}", res.ToString());
                }
            }
            catch (Exception ex)
            {
                resp.code = 2;
                resp.message = "Error while creating device on TTN";
                resp.status = false;
                Log.Error("Exception creating device on TTN: {@data}", ex.Message);
            }
            return resp;
        }

        public async Task<Features.Dto.NsEndDeviceRegistry.End_Device> UpdateNsDeviceAsync(Features.Dto.NsEndDeviceRegistry.EndDeviceDto endDeviceDto)
        {
            Features.Dto.NsEndDeviceRegistry.End_Device device = null;
            try
            {
                var endDeviceJson = new StringContent(
                    JsonSerializer.Serialize(endDeviceDto, _options),
                    Encoding.UTF8,
                    "application/json");

                using var httpResponse =
                    await _httpClient.PutAsync($"ns/applications/ttn-ddoit-test/devices/{endDeviceDto.end_device.ids.device_id}", endDeviceJson);



                if (httpResponse.IsSuccessStatusCode)
                {
                    var stream = await httpResponse.Content.ReadAsStreamAsync();
                    device = await JsonSerializer.DeserializeAsync<Features.Dto.NsEndDeviceRegistry.End_Device>(stream, _options);
                }
                else
                {
                    var stream = await httpResponse.Content.ReadAsStreamAsync();
                    var res = await JsonSerializer.DeserializeAsync<Errorobject>(stream, _options);
                    Log.Information("Error Updating NSDeviceRegistry on TTN: {@data}", res.ToString());
                }
            }
            catch (Exception ex)
            {
                Log.Error("Exception updating nsdevice on TTN: {@data}", ex.Message);
            }
            return device;
        }

        public async Task<Features.Dto.AsEndDeviceRegistry.End_Device> UpdateAsDeviceAsync(Features.Dto.AsEndDeviceRegistry.EndDeviceDto endDeviceDto)
        {
            Features.Dto.AsEndDeviceRegistry.End_Device device = null;
            try
            {

                var endDeviceJson = new StringContent(
                    JsonSerializer.Serialize(endDeviceDto, _options),
                    Encoding.UTF8,
                    "application/json");

                using var httpResponse =
                    await _httpClient.PutAsync($"as/applications/ttn-ddoit-test/devices/{endDeviceDto.end_device.ids.device_id}", endDeviceJson);



                if (httpResponse.IsSuccessStatusCode)
                {
                    var stream = await httpResponse.Content.ReadAsStreamAsync();
                    device = await JsonSerializer.DeserializeAsync<Features.Dto.AsEndDeviceRegistry.End_Device>(stream, _options);
                }
                else
                {
                    var stream = await httpResponse.Content.ReadAsStreamAsync();
                    var res = await JsonSerializer.DeserializeAsync<Errorobject>(stream, _options);
                    Log.Information("Error Updating NSDeviceRegistry on TTN: {@data}", res.ToString());
                }
            }
            catch (Exception ex)
            {
                Log.Error("Exception updating asdevice on TTN: {@data}", ex.Message);
            }
            return device;
        }

        public async Task<Features.Dto.JsEndDeviceRegistry.End_Device> UpdateJsDeviceAsync(Features.Dto.JsEndDeviceRegistry.EndDeviceDto endDeviceDto)
        {
            Features.Dto.JsEndDeviceRegistry.End_Device device = null;
            try
            {
                var endDeviceJson = new StringContent(
                    JsonSerializer.Serialize(endDeviceDto, _options),
                    Encoding.UTF8,
                    "application/json");

                using var httpResponse =
                    await _httpClient.PutAsync($"js/applications/ttn-ddoit-test/devices/{endDeviceDto.end_device.ids.device_id}", endDeviceJson);



                if (httpResponse.IsSuccessStatusCode)
                {
                    var stream = await httpResponse.Content.ReadAsStreamAsync();
                    device = await JsonSerializer.DeserializeAsync<Features.Dto.JsEndDeviceRegistry.End_Device>(stream, _options);
                }
                else
                {
                    var stream = await httpResponse.Content.ReadAsStreamAsync();
                    var res = await JsonSerializer.DeserializeAsync<Errorobject>(stream, _options);
                    Log.Information("Error Updating NSDeviceRegistry on TTN: {@data}", res.ToString());
                }
            }
            catch (Exception ex)
            {
                Log.Error("Exception updating jsdevice on TTN: {@data}", ex.Message);
            }
            return device;
        }
    }
}
