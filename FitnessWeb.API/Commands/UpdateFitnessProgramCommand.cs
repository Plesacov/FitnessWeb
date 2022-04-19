using MediatR;
using System.ComponentModel.DataAnnotations;

namespace FitnessWeb.API.Commands
{
    public class UpdateFitnessProgramCommand : IRequest
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [MaxLength(5000)]
        public string Description { get; set; }
    }
}
