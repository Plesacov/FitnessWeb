using MediatR;

namespace FitnessWeb.API.Commands
{
    public class DeleteFitnessTrainingCommand : IRequest
    {
        public int Id { get; set; }
    }
}
