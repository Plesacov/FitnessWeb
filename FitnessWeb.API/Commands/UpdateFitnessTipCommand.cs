using MediatR;

namespace FitnessWeb.API.Commands
{
    public class UpdateFitnessTipCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
