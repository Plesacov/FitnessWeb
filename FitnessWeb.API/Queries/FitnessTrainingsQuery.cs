using FitnessWeb.API.Pagination;
using FitnessWeb.API.ViewModels;
using MediatR;

namespace FitnessWeb.API.Queries
{
    public class FitnessTrainingsQuery : IRequest<PagedCollectionResponse<TrainingViewModel>>
    {
        public FilterModel Filter { get; set; }
    }
}
