using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessWeb.Models
{
    public class Exercise
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        [Required]
        [Range(1,50)]
        public int CountOfRepeats { get; set; }
        public Training Training { get; set; }
        public int TrainingId   { get; set; }
        [Required]
        [RegularExpression(@"^((http|ftp|https|www)://)?([\w+?\.\w+])+([a-zA-Z0-9\~\!\@\#\$\%\^\&\*\(\)_\-\=\+\\\/\?\.\:\;\'\,]*)?$")]
        public string VideoUrl { get; set; }
    }
}
