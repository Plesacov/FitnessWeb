using Fitness.Infrastracture;
using FitnessWeb.API.Commands;
using FitnessWeb.Models;
using MediatR;

namespace FitnessWeb.API.CommandHandlers
{
    public class UpdateFitnessTrainingCommandHandler : IRequestHandler<UpdateFitnessTrainingCommand, Unit>
    {
        private readonly IRepository<Training> fitnessTrainingRepository;
        public UpdateFitnessTrainingCommandHandler(IRepository<Training> fitnessTrainingRepository)
        {
            this.fitnessTrainingRepository = fitnessTrainingRepository;
        }
        public Task<Unit> Handle(UpdateFitnessTrainingCommand request, CancellationToken cancellationToken)
        {
            var fitnessTraining = this.fitnessTrainingRepository.FindBy(x => x.Id == request.Id).FirstOrDefault();
            if (fitnessTraining != null)
            {
                fitnessTraining.Type = request.Type;
                fitnessTraining.Duration = request.Duration;
                fitnessTrainingRepository.Update(fitnessTraining);
                fitnessTrainingRepository.Save();
            }

            return Task.FromResult(new Unit());
        }
    }
}
