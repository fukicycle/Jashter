using System.Net;

namespace Jashter.Services.Interfaces
{
    public interface IHttpService
    {
        Task<HttpResponse<T>> SendAsync<T>(string path, HttpMethod method, string? content = null);
        class HttpResponse<T>
        {
            public T? Content { get; set; }
            public HttpStatusCode? StatusCode { get; set; }
            public string? ErrorMessage { get; set; }
        }
    }
}
