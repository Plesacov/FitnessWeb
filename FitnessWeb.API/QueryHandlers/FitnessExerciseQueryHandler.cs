using AutoMapper;
using Fitness.Infrastracture;
using FitnessWeb.API.Pagination;
using FitnessWeb.API.Queries;
using FitnessWeb.API.ViewModels;
using FitnessWeb.Models;
using MediatR;

namespace FitnessWeb.API.QueryHandlers
{
    public class FitnessExercisesQueryHandler : IRequestHandler<FitnessExercisesQuery, PagedCollectionResponse<ExerciseViewModel>>
    {

        private readonly IRepository<Exercise> fitnesExerciseRepository;
        private readonly IMapper mapper;
        public FitnessExercisesQueryHandler(IRepository<Exercise> fitnessExerciseRepository, IMapper mapper)
        {
            this.fitnesExerciseRepository = fitnessExerciseRepository;
            this.mapper = mapper;
        }
        public Task<PagedCollectionResponse<ExerciseViewModel>> Handle(FitnessExercisesQuery request, CancellationToken cancellationToken)
        {
            var propertyInfo = typeof(Exercise);
            var property = propertyInfo.GetProperty(request.Filter.SortedField ?? "Name");
            var fitnessExercise = this.fitnesExerciseRepository.GetWithInclude(x => x.Training != null, x => x.Training);

            if (string.IsNullOrEmpty(request.Filter.Term) || request.Filter.Term == "")
            {
                fitnessExercise = request.Filter.SortAsc
                    ? fitnessExercise.OrderBy(p => property.GetValue(p)).ToList()
                    : fitnessExercise.OrderByDescending(p => property.GetValue(p)).ToList();
                return Task.FromResult(PagedCollectionResponse<ExerciseViewModel>.Create(fitnessExercise, request.Filter, (p) => mapper.Map<ExerciseViewModel>(p)));
            }

            fitnessExercise = fitnessExercise.Where(u => u.Name.ToLower().StartsWith(request.Filter.Term) || u.CountOfRepeats.ToString().StartsWith(request.Filter.Term)).ToList();
            fitnessExercise = request.Filter.SortAsc ? fitnessExercise.OrderBy(p => property.GetValue(p)).ToList() : fitnessExercise.OrderByDescending(p => property.GetValue(p)).ToList();

            var result = PagedCollectionResponse<ExerciseViewModel>.Create(fitnessExercise, request.Filter, (p) => mapper.Map<ExerciseViewModel>(p));
            return Task.FromResult(result);
        }
    }
}
