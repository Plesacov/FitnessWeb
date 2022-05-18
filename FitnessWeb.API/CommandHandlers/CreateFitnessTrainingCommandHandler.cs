using Fitness.Infrastracture;
using FitnessWeb.API.Commands;
using FitnessWeb.Models;
using MediatR;

namespace FitnessWeb.API.CommandHandlers
{
    public class CreateFitnessTrainingCommandHandler : IRequestHandler<CreateFitnessTrainingCommand, int>
    {
        private readonly IRepository<FitnessProgram> fitnessProgramRepository;
        public CreateFitnessTrainingCommandHandler(IRepository<FitnessProgram> fitnessProgramRepository)
        {
            this.fitnessProgramRepository = fitnessProgramRepository;
        }
        public Task<int> Handle(CreateFitnessTrainingCommand command, CancellationToken cancellationToken)
        {
            FitnessProgram fitnessProgram = this.fitnessProgramRepository.GetWithInclude(x => x.FitnessTypeId == command.FitnessProgramId, x => x.Trainings).FirstOrDefault();
            if (fitnessProgram != null)
            {
                fitnessProgram.Trainings.Add(new Training { Type = command.Type, Duration = command.Duration });
                fitnessProgramRepository.Save();
            }

            var resultId = fitnessProgram.Id;
            return Task.FromResult(resultId);
        }
    }
}
