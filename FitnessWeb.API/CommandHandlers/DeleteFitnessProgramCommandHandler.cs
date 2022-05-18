using Fitness.Core.Models;
using Fitness.Infrastracture;
using FitnessWeb.API.Commands;
using FitnessWeb.Models;
using MediatR;

namespace FitnessWeb.API.CommandHandlers
{
    public class DeleteFitnessProgramCommandHandler : IRequestHandler<DeleteFitnessProgramCommand, Unit>
    {
        private readonly IRepository<FitnessType> fitnessTypeRepository;
        public DeleteFitnessProgramCommandHandler(IRepository<FitnessType> fitnessProgramRepository)
        {
            this.fitnessTypeRepository = fitnessProgramRepository;
        }
        public Task<Unit> Handle(DeleteFitnessProgramCommand request, CancellationToken cancellationToken)
        {
            var fitnessProgram = this.fitnessTypeRepository.GetById(request.Id);
            if(fitnessProgram != null)
            {
                fitnessTypeRepository.Delete(fitnessProgram.FitnessProgramId);
                fitnessTypeRepository.Save();
            }
            return Task.FromResult(new Unit());
        }
    }
}
