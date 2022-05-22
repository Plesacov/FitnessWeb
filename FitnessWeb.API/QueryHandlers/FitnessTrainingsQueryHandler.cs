using AutoMapper;
using Fitness.Infrastracture;
using FitnessWeb.API.Pagination;
using FitnessWeb.API.Queries;
using FitnessWeb.API.ViewModels;
using FitnessWeb.Models;
using MediatR;

namespace FitnessWeb.API.QueryHandlers
{
    public class FitnessTrainingsQueryHandler : IRequestHandler<FitnessTrainingsQuery, PagedCollectionResponse<TrainingViewModel>>
    {

        private readonly IRepository<Training> fitnesTrainingRepository;
        private readonly IMapper mapper;
        public FitnessTrainingsQueryHandler(IRepository<Training> fitnessProgramRepository, IMapper mapper)
        {
            this.fitnesTrainingRepository = fitnessProgramRepository;
            this.mapper = mapper;
        }
        public Task<PagedCollectionResponse<TrainingViewModel>> Handle(FitnessTrainingsQuery request, CancellationToken cancellationToken)
        {
            var propertyInfo = typeof(Training);
            var property = propertyInfo.GetProperty(request.Filter.SortedField ?? "Type");
            var fitnessTrainings = this.fitnesTrainingRepository.GetWithInclude(x => x.FitnessProgram != null, x => x.FitnessProgram, x => x.FitnessProgram.FitnessType);

            if (string.IsNullOrEmpty(request.Filter.Term) || request.Filter.Term == "")
            {
                fitnessTrainings = request.Filter.SortAsc
                    ? fitnessTrainings.OrderBy(p => property.GetValue(p)).ToList()
                    : fitnessTrainings.OrderByDescending(p => property.GetValue(p)).ToList();
                return Task.FromResult(PagedCollectionResponse<TrainingViewModel>.Create(fitnessTrainings, request.Filter, (p) => mapper.Map<TrainingViewModel>(p)));
            }

            fitnessTrainings = fitnessTrainings.Where(u => u.Type.ToLower().StartsWith(request.Filter.Term) || u.Duration.ToString().StartsWith(request.Filter.Term)).ToList();
            fitnessTrainings = request.Filter.SortAsc ? fitnessTrainings.OrderBy(p => property.GetValue(p)).ToList() : fitnessTrainings.OrderByDescending(p => property.GetValue(p)).ToList();

            var result = PagedCollectionResponse<TrainingViewModel>.Create(fitnessTrainings, request.Filter, (p) => mapper.Map<TrainingViewModel>(p));
            return Task.FromResult(result);
        }
    }
}
