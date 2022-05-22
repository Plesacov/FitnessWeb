using Fitness.Infrastracture;
using FitnessWeb.API.Commands;
using FitnessWeb.Models;
using MediatR;

namespace FitnessWeb.API.CommandHandlers
{
    public class DeleteFitnessExerciseCommandHandler : IRequestHandler<DeleteFitnessExerciseCommand, Unit>
    {
        private readonly IRepository<Exercise> fitnessExerciseRepository;
        public DeleteFitnessExerciseCommandHandler(IRepository<Exercise> fitnessRepositoryExercise)
        {
            this.fitnessExerciseRepository = fitnessRepositoryExercise;
        }
        public Task<Unit> Handle(DeleteFitnessExerciseCommand request, CancellationToken cancellationToken)
        {
            var fitnessExercise = this.fitnessExerciseRepository.GetById(request.Id);
            if (fitnessExercise != null)
            {
                fitnessExerciseRepository.Delete(fitnessExercise.Id);
                fitnessExerciseRepository.Save();
            }
            return Task.FromResult(new Unit());
        }
    }
}
