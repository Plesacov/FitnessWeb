using FitnessWeb.API.ViewModels;
using MediatR;

namespace FitnessWeb.API.Queries
{
    public class FitnessProgramQuery : IRequest<List<FitnessProgramViewModel>>
    {
        public string SearchTerm { get; set; }
    }
}
