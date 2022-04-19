using Fitness.Core.Models;
using Fitness.Infrastracture;
using FitnessWeb.API.Commands;
using MediatR;

namespace FitnessWeb.API.CommandHandlers
{
    public class PartialUpdateFitnessProgramCommandHandler : IRequestHandler<PartialUpdateFitnessProgramCommand, Unit>
    {
        private readonly IRepository<FitnessType> fitnessProgramRepository;
        public PartialUpdateFitnessProgramCommandHandler(IRepository<FitnessType> fitnessProgramRepository)
        {
            this.fitnessProgramRepository = fitnessProgramRepository;
        }
        public Task<Unit> Handle(PartialUpdateFitnessProgramCommand request, CancellationToken cancellationToken)
        {
            var fitnessProgram = this.fitnessProgramRepository.FindBy(x => x.FitnessProgramId == request.Id).FirstOrDefault();

            if (fitnessProgram != null)
            {
                if (request.Name != null)
                {
                    fitnessProgram.Name = request.Name;
                }
                if (request.Description != null)
                {
                    fitnessProgram.Description = request.Description;
                }
                fitnessProgramRepository.Update(fitnessProgram);
                fitnessProgramRepository.Save();
            }

            return Task.FromResult(new Unit());
        }
    }
}
