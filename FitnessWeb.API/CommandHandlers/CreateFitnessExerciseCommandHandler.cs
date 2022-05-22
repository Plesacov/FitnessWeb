using Fitness.Infrastracture;
using FitnessWeb.API.Commands;
using FitnessWeb.Models;
using MediatR;

namespace FitnessWeb.API.CommandHandlers
{
    public class CreateFitnessExerciseCommandHandler : IRequestHandler<CreateFitnessExerciseCommand, int>
    {
        private readonly IRepository<Training> fitnessTrainingRepository;
        public CreateFitnessExerciseCommandHandler(IRepository<Training> fitnessTrainingRepository)
        {
            this.fitnessTrainingRepository = fitnessTrainingRepository;
        }
        public Task<int> Handle(CreateFitnessExerciseCommand command, CancellationToken cancellationToken)
        {
            Training fitnessTraining = this.fitnessTrainingRepository.GetWithInclude(x => x.Id == command.FitnessTrainingId, x => x.Exercises).FirstOrDefault();
            if (fitnessTraining != null)
            {
                fitnessTraining.Exercises.Add(new Exercise { Name = command.Name, CountOfRepeats = command.CountOfRepeats, VideoUrl = command.VideoUrl });
                fitnessTrainingRepository.Save();
            }

            var resultId = fitnessTraining.Id;
            return Task.FromResult(resultId);
        }
    }
}
