using MediatR;

namespace FitnessWeb.API.Commands
{
    public class UploadImageCommand : IRequest
    {
        public int UserId { get; set; }
    }
}
