using Fitness.Infrastracture;
using FitnessWeb.API.Commands;
using FitnessWeb.Models;
using MediatR;

namespace FitnessWeb.API.CommandHandlers
{
    public class DeleteFitnessTrainingCommandHandler : IRequestHandler<DeleteFitnessTrainingCommand, Unit>
    {
        private readonly IRepository<Training> fitnessTrainingRepository;
        public DeleteFitnessTrainingCommandHandler(IRepository<Training> fitnessTrainingRepository)
        {
            this.fitnessTrainingRepository = fitnessTrainingRepository;
        }
        public Task<Unit> Handle(DeleteFitnessTrainingCommand request, CancellationToken cancellationToken)
        {
            var fitnessTraining = this.fitnessTrainingRepository.GetById(request.Id);
            if (fitnessTraining != null)
            {
                fitnessTrainingRepository.Delete(fitnessTraining.Id);
                fitnessTrainingRepository.Save();
            }
            return Task.FromResult(new Unit());
        }
    }
}
