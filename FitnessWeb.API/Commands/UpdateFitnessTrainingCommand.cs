using MediatR;

namespace FitnessWeb.API.Commands
{
    public class UpdateFitnessTrainingCommand : IRequest
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int Duration { get; set; }
    }
}
