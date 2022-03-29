using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessWeb.Models
{
    public class FitnessProgram : BaseEntity
    {
        [Required]
        [MaxLength(20)]
        public string Type { get; set; } // change enum <--
        public List<Training> Trainings { get; set; }
        public List<FitnessTip> FitnessTips { get; set; }
        public List<PersonFitnessProgram> PersonFitnessPrograms { get; set; }
    }
}
