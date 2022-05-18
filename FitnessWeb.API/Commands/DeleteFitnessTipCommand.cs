using MediatR;

namespace FitnessWeb.API.Commands
{
    public class DeleteFitnessTipCommand : IRequest
    {
        public int Id { get; set; }
    }
}
