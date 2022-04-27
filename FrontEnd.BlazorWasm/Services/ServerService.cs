using FrondEnd.Shared.DTOs;
using FrondEnd.Shared.Models;
using FrontEnd.BlazorWasm.Services.Interfaces;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace FrontEnd.BlazorWasm.Services
{
    public class ServerService : IServerService
    {

        private readonly HttpClient _httpClient;
        private readonly ILogger<ServerService> _logger;

        public ServerService(HttpClient httpClient, ILogger<ServerService> logger)
        {
            _logger = logger;
            _httpClient = httpClient;
        }

        public async Task<Response<string>> AuthenticateAsync(UserDTO user)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("/api/Authentication/authenticate", user);
                if (response.IsSuccessStatusCode)
                {
                    var rawResponseData = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<Response<string>>(rawResponseData);
                    return data!;
                }

                _logger.LogWarning("The request returned with the status {0}", response.StatusCode);
                var rawError = await response.Content.ReadAsStringAsync();
                var error = JsonConvert.DeserializeObject<Response<string>>(rawError);
                return error!;
            }
            catch (Exception e)
            {
                _logger.LogError(new EventId(500, "internal error"), e, "An error occured when processing");
                return new Response<string>("ERROR", "Failed to process, something went wrong");
            }
        }

        public async Task<Response<IReadOnlyList<Products>>> GetProductsAsync(string token)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                var response = await _httpClient.GetFromJsonAsync<Response<IReadOnlyList<Products>>>("/api/Products/get-products");
                return response!;
            }
            catch (Exception e)
            {
                _logger.LogError(new EventId(500, "Internal error"), e, "Error while processing");
                return new Response<IReadOnlyList<Products>>("ERROR", "Failed to get data");
            }
        }

        public async Task<Response<Products>> GetProductsDetailsAsync(string token, string id)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                //TODO: the de get_by_id api. to be implemented

                //return result
                return new Response<Products>("SUCCESS", "details get");//this is jus a similation
            }
            catch (Exception e)
            {
                _logger.LogError(new EventId(500, "internal error"), e, "An error occured while processing");
                return new Response<Products>("ERROR", "Failed to get result");
            }
        }
    }
}
