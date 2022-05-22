using FitnessWeb.API.Pagination;
using FitnessWeb.API.ViewModels;
using MediatR;

namespace FitnessWeb.API.Queries
{
    public class FitnessExercisesQuery : IRequest<PagedCollectionResponse<ExerciseViewModel>>
    {
        public FilterModel Filter { get; set; }
    }
}
