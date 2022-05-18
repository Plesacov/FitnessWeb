using AutoMapper;
using Fitness.Infrastracture;
using FitnessWeb.API.Queries;
using FitnessWeb.API.ViewModels;
using FitnessWeb.Models;
using MediatR;

namespace FitnessWeb.API.QueryHandlers
{
    public class FindPersonFitnessProgramQueryHandler : IRequestHandler<FindPersonFitnessProgramQuery, FitnessProgramViewModel>
    {
        private readonly IRepository<PersonFitnessProgram> personProgramRepository;
        private readonly IMapper mapper;
        private readonly IRepository<FitnessProgram> programRepository;
        private readonly IRepository<Training> trainingRepository;
        public FindPersonFitnessProgramQueryHandler(IRepository<PersonFitnessProgram> personProgramRepository, 
            IMapper mapper, 
            IRepository<FitnessProgram> programRepository,
            IRepository<Training> trainingRepository)
        {
            this.personProgramRepository = personProgramRepository;
            this.mapper = mapper;
            this.programRepository = programRepository;
            this.trainingRepository = trainingRepository;
        }
        public Task<FitnessProgramViewModel> Handle(FindPersonFitnessProgramQuery request, CancellationToken cancellationToken)
        {
            var fitnessPrograms = this.personProgramRepository
                .FindBy(x => x.PersonId == request.UserId && x.IsCurrent).ToList();

            if (fitnessPrograms.Count > 0)
            {
                var fitnessProgramId = fitnessPrograms.Select(x => x.FitnessProgramId).First();
                FitnessProgram? fitnessProgram = this.programRepository
                    .GetWithInclude(x => x.Id == fitnessProgramId, 
                                    x => x.FitnessTips, 
                                    x => x.FitnessType)
                    .FirstOrDefault();
                List<Training> trainings = this.trainingRepository
                    .GetWithInclude(x => x.FitnessProgramId == fitnessProgramId, 
                                    x => x.Exercises)
                    .ToList();
                FitnessProgramViewModel result = mapper.Map<FitnessProgramViewModel>(fitnessProgram);
                result.Trainings = mapper.Map<List<TrainingViewModel>>(trainings);
                return Task.FromResult(result);
            }

            return Task.FromResult<FitnessProgramViewModel>(null);
        }
    }
}
