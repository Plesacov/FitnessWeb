using MediatR;

namespace FitnessWeb.API.Commands
{
    public class CreateFitnessTrainingCommand : IRequest<int>
    {
        public int FitnessProgramId { get; set; }
        public string Type { get; set; }
        public int Duration { get; set; }
    }
}
