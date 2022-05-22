using MediatR;

namespace FitnessWeb.API.Commands
{
    public class UpdateFitnessExerciseCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountOfRepeats { get; set; }
        public string VideoUrl { get; set; }
    }
}
