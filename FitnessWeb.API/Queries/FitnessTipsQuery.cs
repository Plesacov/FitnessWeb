using FitnessWeb.API.Pagination;
using FitnessWeb.API.ViewModels;
using MediatR;

namespace FitnessWeb.API.Queries
{
    public class FitnessTipsQuery : IRequest <PagedCollectionResponse<FitnessTipViewModel>>
    {
        public FilterModel Filter { get; set; } 
    }
}
