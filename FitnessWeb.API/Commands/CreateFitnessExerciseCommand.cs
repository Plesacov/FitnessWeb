using MediatR;

namespace FitnessWeb.API.Commands
{
    public class CreateFitnessExerciseCommand : IRequest<int>
    {
        public int FitnessTrainingId { get; set; }
        public string Name { get; set; }
        public int CountOfRepeats { get; set; }
        public string VideoUrl { get; set; }
    }
}
