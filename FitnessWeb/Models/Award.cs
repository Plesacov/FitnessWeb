using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessWeb.Models
{
    public class Award : BaseEntity
    {
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        [Required]
        [MaxLength(30)]
        public string Type { get; set; }
        public Achievement Achievement { get; set; }
        public int AchievementId { get; set; }
        public byte[] Timestamp { get; set; }
    }
}
