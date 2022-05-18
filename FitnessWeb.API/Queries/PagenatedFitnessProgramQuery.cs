using FitnessWeb.API.Pagination;
using FitnessWeb.API.ViewModels;
using MediatR;

namespace FitnessWeb.API.Queries
{
    public class PagenatedFitnessProgramQuery : IRequest<PagedCollectionResponse<FitnessTypeViewModel>>
    {
        public FilterModel Filter { get; set; }
    }
}
