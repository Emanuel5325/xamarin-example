using System.Net;
using System.Net.Http.Headers;

namespace MauiExample.Models.Work
{
    public class ApiRequestResult
    {
        public bool HasError { get; set; }

        public string ErrorMessage { get; set; }

        public HttpStatusCode StatusCode { get; set; }

        public HttpResponseHeaders Headers { get; set; }
    }

    public class ApiRequestResult<T> : ApiRequestResult
    {
        public T Data { get; set; }
    }
}
