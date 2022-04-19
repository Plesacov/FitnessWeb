using Fitness.Core.Models;
using Fitness.Infrastracture;
using FitnessWeb.API.Commands;
using FitnessWeb.Models;
using MediatR;

namespace FitnessWeb.API.CommandHandlers
{
    public class UpdateFitnessProgramCommandHandler : IRequestHandler<UpdateFitnessProgramCommand, Unit>
    {
        private readonly IRepository<FitnessType> fitnessProgramRepository;
        public UpdateFitnessProgramCommandHandler(IRepository<FitnessType> fitnessProgramRepository)
        {
            this.fitnessProgramRepository = fitnessProgramRepository;
        }
        public Task<Unit> Handle(UpdateFitnessProgramCommand request, CancellationToken cancellationToken)
        {
            var fitnessProgram = this.fitnessProgramRepository.FindBy(x => x.FitnessProgramId == request.Id).FirstOrDefault();
            if (fitnessProgram != null)
            {
                fitnessProgram.Name = request.Name;
                fitnessProgram.Description = request.Description;
                fitnessProgramRepository.Update(fitnessProgram);
                fitnessProgramRepository.Save();
            }

            return Task.FromResult(new Unit());
        }
    }
}
