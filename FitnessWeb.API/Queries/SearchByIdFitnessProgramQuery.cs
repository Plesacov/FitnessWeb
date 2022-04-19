using FitnessWeb.API.ViewModels;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace FitnessWeb.API.Queries
{
    public class SearchByIdFitnessProgramQuery : IRequest<FitnessProgramViewModel>
    {
        [Required]
        public int Id { get; set; }
    }
}
