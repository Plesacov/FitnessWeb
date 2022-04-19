using System.Net;

namespace FitnessWeb.API.Exceptions
{
    public class EntityAlreadyExistException : ApiException
    {
        public EntityAlreadyExistException(string message) : base(HttpStatusCode.BadRequest, message)
        {
        }
    }
}
