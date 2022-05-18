using FitnessWeb.API.ViewModels;
using MediatR;

namespace FitnessWeb.API.Queries
{
    public class FindPersonFitnessProgramQuery : IRequest<FitnessProgramViewModel>
    {
        public int UserId { get; set; }
    }
}
