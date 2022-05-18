using FitnessWeb.API.ViewModels;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace FitnessWeb.API.Commands
{
    public class AssignFitnessProgramToUserCommand : IRequest<FitnessProgramViewModel>
    {
        public int FitnessTypeId { get; set; }

        public int UserId { get; set; }

        public string FitnessLevel { get; set; }
    }
}
