using MediatR;

namespace FitnessWeb.API.Commands
{
    public class CreateFitnessTipCommand : IRequest<int>
    {
        public int FitnessProgramId { get; set; }
        public string Name  { get; set; }
        public string Description { get; set; }
    }
}
