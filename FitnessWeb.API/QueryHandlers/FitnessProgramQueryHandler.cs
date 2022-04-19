using AutoMapper;
using Fitness.Infrastracture;
using FitnessWeb.API.Queries;
using FitnessWeb.API.ViewModels;
using FitnessWeb.Models;
using MediatR;

namespace FitnessWeb.API.QueryHandlers
{
    public class FitnessProgramQueryHandler : IRequestHandler<FitnessProgramQuery, List<FitnessProgramViewModel>>
    {
        private readonly IRepository<FitnessProgram> fitnessProgramRepository;
        private readonly IMapper mapper;
        public FitnessProgramQueryHandler(IRepository<FitnessProgram> fitnessProgramRepository, IMapper mapper)
        {
            this.fitnessProgramRepository = fitnessProgramRepository;
            this.mapper = mapper;
        }
        public Task<List<FitnessProgramViewModel>> Handle(FitnessProgramQuery request, CancellationToken cancellationToken)
        {
            var fitnessPrograms = fitnessProgramRepository
                .GetWithInclude(x => x.FitnessType.Name.Contains(request.SearchTerm),
                                    x => x.Trainings,
                                    x => x.FitnessTips,
                                    x => x.FitnessType);
            var result = mapper.Map<List<FitnessProgramViewModel>>(fitnessPrograms);
            return Task.FromResult(result);
        }
    }
}
