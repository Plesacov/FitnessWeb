using Fitness.Infrastracture;
using FitnessWeb.API.Commands;
using FitnessWeb.Models;
using MediatR;

namespace FitnessWeb.API.CommandHandlers
{
    public class UpdateFitnessExerciseCommandHandler : IRequestHandler<UpdateFitnessExerciseCommand, Unit>
    {
        private readonly IRepository<Exercise> fitnessExerciseRepository;
        public UpdateFitnessExerciseCommandHandler(IRepository<Exercise> fitnessExerciseRepository)
        {
            this.fitnessExerciseRepository = fitnessExerciseRepository;
        }
        public Task<Unit> Handle(UpdateFitnessExerciseCommand request, CancellationToken cancellationToken)
        {
            var fitnessExercise = this.fitnessExerciseRepository.FindBy(x => x.Id == request.Id).FirstOrDefault();
            if (fitnessExercise != null)
            {
                fitnessExercise.Name = request.Name;
                fitnessExercise.CountOfRepeats = request.CountOfRepeats;
                fitnessExercise.VideoUrl = request.VideoUrl;
                fitnessExerciseRepository.Update(fitnessExercise);
                fitnessExerciseRepository.Save();
            }

            return Task.FromResult(new Unit());
        }
    }
}
