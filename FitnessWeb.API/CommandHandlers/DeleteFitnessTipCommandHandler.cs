using Fitness.Infrastracture;
using FitnessWeb.API.Commands;
using FitnessWeb.Models;
using MediatR;

namespace FitnessWeb.API.CommandHandlers
{
    public class DeleteFitnessTipCommandHandler : IRequestHandler<DeleteFitnessTipCommand, Unit>
    {
        private readonly IRepository<FitnessTip> fitnessTipRepository;
        public DeleteFitnessTipCommandHandler(IRepository<FitnessTip> fitnessTipRepository)
        {
            this.fitnessTipRepository = fitnessTipRepository;
        }
        public Task<Unit> Handle(DeleteFitnessTipCommand request, CancellationToken cancellationToken)
        {
            var fitnessTip = this.fitnessTipRepository.GetById(request.Id);
            if (fitnessTip != null)
            {
                fitnessTipRepository.Delete(fitnessTip.Id);
                fitnessTipRepository.Save();
            }
            return Task.FromResult(new Unit());
        }
    }

}
