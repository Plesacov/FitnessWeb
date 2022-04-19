using MediatR;
using System.ComponentModel.DataAnnotations;

namespace FitnessWeb.API.Commands
{
    public class DeleteFitnessProgramCommand : IRequest
    {
        [Required]
        public int Id { get; set; }
    }
}
