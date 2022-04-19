using Fitness.Infrastracture;
using FitnessWeb.API.Commands;
using FitnessWeb.Models;
using MediatR;

namespace FitnessWeb.API.CommandHandlers
{
    public class DeleteFitnessProgramCommandHandler : IRequestHandler<DeleteFitnessProgramCommand, Unit>
    {
        private readonly IRepository<FitnessProgram> fitnessProgramRepository;
        public DeleteFitnessProgramCommandHandler(IRepository<FitnessProgram> fitnessProgramRepository)
        {
            this.fitnessProgramRepository = fitnessProgramRepository;
        }
        public Task<Unit> Handle(DeleteFitnessProgramCommand request, CancellationToken cancellationToken)
        {
            var fitnessProgram = this.fitnessProgramRepository.GetById(request.Id);
            if(fitnessProgram != null)
            {
                fitnessProgramRepository.Delete(fitnessProgram.Id);
                fitnessProgramRepository.Save();
            }
            return Task.FromResult(new Unit());
        }
    }
}
