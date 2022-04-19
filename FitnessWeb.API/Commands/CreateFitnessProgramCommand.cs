using MediatR;
using System.ComponentModel.DataAnnotations;

namespace FitnessWeb.API.Commands
{
    public class CreateFitnessProgramCommand : IRequest<int>
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
  
        [MaxLength(5000)]
        public string Description { get; set; }
    }
}
