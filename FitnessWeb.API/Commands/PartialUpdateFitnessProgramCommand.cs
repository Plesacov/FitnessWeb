using MediatR;
using System.ComponentModel.DataAnnotations;

namespace FitnessWeb.API.Commands
{
    public class PartialUpdateFitnessProgramCommand : IRequest
    {
        [Required]
        public int Id { get; set; }

        [MaxLength(30)]
        public string? Name { get; set; }

        [MaxLength(5000)]
        public string? Description { get; set; }
    }
}
