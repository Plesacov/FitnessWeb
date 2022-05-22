using FitnessWeb.API.ViewModels;
using MediatR;

namespace FitnessWeb.API.Queries
{
    public class GetAllTrainingsQuery : IRequest<List<TrainingViewModel>>
    {
    }
}
