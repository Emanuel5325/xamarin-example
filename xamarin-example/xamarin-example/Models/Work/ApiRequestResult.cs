using System.Net;
using System.Net.Http.Headers;

namespace Models.Work
{
    public class APIRequestResult
    {
        public bool HasError { get; set; }

        public string ErrorMessage { get; set; }

        public HttpStatusCode StatusCode { get; set; }

        public HttpResponseHeaders Headers { get; set; }
    }

    public class APIRequestResult<T> : APIRequestResult
    {
        public T Data { get; set; }
    }
}
