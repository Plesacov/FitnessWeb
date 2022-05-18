using FitnessWeb.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.Core.Models
{
    
    public class FitnessType
    {

        public int Id { get; set; }
        [Timestamp]
        public byte[] Timestamp { get; set; }

        [ConcurrencyCheck]
        public string Name { get; set; }
        public string Description { get; set; }
        public FitnessProgram FitnessProgram { get; set; }
        public int FitnessProgramId { get; set; }
    }
}
