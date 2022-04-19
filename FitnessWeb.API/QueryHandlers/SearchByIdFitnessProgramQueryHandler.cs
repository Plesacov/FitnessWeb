using AutoMapper;
using Fitness.Infrastracture;
using FitnessWeb.API.Exceptions;
using FitnessWeb.API.Queries;
using FitnessWeb.API.ViewModels;
using FitnessWeb.Models;
using MediatR;

namespace FitnessWeb.API.QueryHandlers
{
    public class SearchByIdFitnessProgramQueryHandler : IRequestHandler<SearchByIdFitnessProgramQuery, FitnessProgramViewModel>
    {
        private readonly IRepository<FitnessProgram> fitnessProgramRepository;
        private readonly IMapper mapper;
        public SearchByIdFitnessProgramQueryHandler(IRepository<FitnessProgram> fitnessProgramRepository, IMapper mapper)
        {
            this.fitnessProgramRepository = fitnessProgramRepository;
            this.mapper = mapper;
        }
        public Task<FitnessProgramViewModel> Handle(SearchByIdFitnessProgramQuery request, CancellationToken cancellationToken)
        {
            FitnessProgram? fitnessProgram = fitnessProgramRepository.GetWithInclude(x => x.Id == request.Id, x => x.Trainings, x => x.FitnessTips, x => x.FitnessType).FirstOrDefault();
            FitnessProgramViewModel result = mapper.Map<FitnessProgramViewModel>(fitnessProgram);

            if(result == null)
            {
                throw new NotFoundException("Entity is not found");
            }

            return Task.FromResult(result);
        }
    }
}
