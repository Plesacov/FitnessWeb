using MediatR;

namespace FitnessWeb.API.Commands
{
    public class DeleteFitnessExerciseCommand : IRequest
    {
        public int Id { get; set; }
    }
}
