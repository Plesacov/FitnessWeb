using System.Net;

namespace FitnessWeb.API.Exceptions
{
    public class ApiException : Exception
    {
        public HttpStatusCode Code { get; }

        public ApiException(HttpStatusCode code, string message) : base(message)
        {
            Code = code;
        }
    }
}
