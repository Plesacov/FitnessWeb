using Fitness.Core.Models;
using Fitness.Infrastracture;
using FitnessWeb.API.Commands;
using FitnessWeb.Models;
using MediatR;

namespace FitnessWeb.API.CommandHandlers
{
    public class CreateFitnessTipCommandHandler : IRequestHandler<CreateFitnessTipCommand, int>
    {
        private readonly IRepository<FitnessProgram> fitnessProgramRepository;
        public CreateFitnessTipCommandHandler(IRepository<FitnessProgram> fitnessProgramRepository)
        {
            this.fitnessProgramRepository = fitnessProgramRepository;
        }
        public Task<int> Handle(CreateFitnessTipCommand command, CancellationToken cancellationToken)
        {
            FitnessProgram fitnessProgram = this.fitnessProgramRepository.GetWithInclude(x => x.FitnessTypeId == command.FitnessProgramId, x => x.FitnessTips).FirstOrDefault();
            if (fitnessProgram != null)
            {
                fitnessProgram.FitnessTips.Add(new FitnessTip { Name = command.Name, Description = command.Description });
                fitnessProgramRepository.Save();
            }

            var resultId = fitnessProgram.Id;
            return Task.FromResult(resultId);
        }
    }
}
