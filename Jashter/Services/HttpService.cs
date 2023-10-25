using Blazored.LocalStorage;
using Jashter.Services.Interfaces;
using Jashter.Shared;
using Newtonsoft.Json;
using System.Net;

namespace Jashter.Services
{
    public class HttpService : IHttpService
    {
        private readonly HttpClient _httpClient;
        private readonly IJsonConvertService _jsonConvertService;
        private readonly ITokenService _tokenService;
        private readonly ILogger<HttpService> _logger;
        public HttpService(HttpClient httpClient, IJsonConvertService jsonConvertService, ITokenService tokenService, ILogger<HttpService> logger)
        {
            _httpClient = httpClient;
            _jsonConvertService = jsonConvertService;
            _tokenService = tokenService;
            _logger = logger;
        }


        async Task<IHttpService.HttpResponse<T>> IHttpService.SendAsync<T>(string path, HttpMethod method, string? requestContent)
        {
            IHttpService.HttpResponse<T> httpResponse = new IHttpService.HttpResponse<T>();
            try
            {
                HttpRequestMessage httpRequestMessage = new HttpRequestMessage();
                httpRequestMessage.Method = method;
                httpRequestMessage.RequestUri = new Uri(_httpClient.BaseAddress!.AbsoluteUri + path);
                if (await _tokenService.Exists())
                {
                    string? jwt = await _tokenService.GetTokenAsync();
                    httpRequestMessage.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", jwt);
                }
                if (requestContent is not null)
                {
                    StringContent requestHttpContent = new StringContent(requestContent, System.Text.Encoding.UTF8, "application/json");
                    httpRequestMessage.Content = requestHttpContent;
                }
                HttpResponseMessage httpResponseMessage = await _httpClient.SendAsync(httpRequestMessage);
                httpResponseMessage.EnsureSuccessStatusCode();
                HttpContent responseHttpContent = httpResponseMessage.Content;
                string responseContent = await responseHttpContent.ReadAsStringAsync();
                T content = _jsonConvertService.Deserialize<T>(responseContent);
                httpResponse.Content = content;
                httpResponse.StatusCode = httpResponseMessage.StatusCode;
                httpResponse.ErrorMessage = null;
            }
            catch (HttpRequestException ex)
            {
                httpResponse.Content = default;
                httpResponse.ErrorMessage = ex.Message;
                httpResponse.StatusCode = ex.StatusCode;
                _logger.LogError(ex.InnerException?.Message);
            }
            catch (Exception ex)
            {
                httpResponse.Content = default;
                httpResponse.ErrorMessage = ex.Message;
                httpResponse.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                _logger.LogError(ex.InnerException?.Message);
            }
            return httpResponse;
        }
    }
}
