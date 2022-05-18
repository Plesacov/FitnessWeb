using Fitness.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessWeb.Models
{
    public class FitnessProgram

    {
        public int Id { get; set; }
        public List<Training> Trainings { get; set; }
        public List<FitnessTip> FitnessTips { get; set; }
        public List<PersonFitnessProgram> PersonFitnessPrograms { get; set; }
        public FitnessType FitnessType { get; set; }
        public int FitnessTypeId { get; set; }
    }
}
