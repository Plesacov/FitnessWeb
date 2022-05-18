using AutoMapper;
using Fitness.Core.Models;
using Fitness.Infrastracture;
using FitnessWeb.API.Queries;
using FitnessWeb.API.ViewModels;
using MediatR;

namespace FitnessWeb.API.QueryHandlers
{
    public class FitnessTypesQueryHandler : IRequestHandler<FitnessTypesQuery, List<FitnessTypeViewModel>>
    {

        private readonly IRepository<FitnessType> fitnessProgramRepository;
        private readonly IMapper mapper;
        public FitnessTypesQueryHandler(IRepository<FitnessType> fitnessProgramRepository, IMapper mapper)
        {
            this.fitnessProgramRepository = fitnessProgramRepository;
            this.mapper = mapper;
        }
        public Task<List<FitnessTypeViewModel>> Handle(FitnessTypesQuery request, CancellationToken cancellationToken)
        {
            List<FitnessType> fitnessTypes = this.fitnessProgramRepository.GetAll().ToList();
            var fitnessTypesViewModels = mapper.Map<List<FitnessTypeViewModel>>(fitnessTypes);
            return Task.FromResult(fitnessTypesViewModels);
        }
    }
}
