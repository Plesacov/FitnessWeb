﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessWeb.Models
{
    public class Person : BaseEntity, IUser
    {
        [Required]
        [MaxLength(20)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(20)]
        public string LastName { get; set; }
        [Required]
        public DateTime BirthdayDate { get; set; }
        [Required]
        public int Height { get; set; }
        [Required]
        public int Weight { get; set; }
        [Required]
        public FitnessLevel FitnessLevel { get; set; }
        public List<Achievement> Achievements { get; set; }
        public bool? IsVip { get; set; }
        public List<PersonFitnessProgram> PersonFitnessPrograms { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
    }
    public enum FitnessLevel
    {
        Beginner,
        Middle,
        Advanced
    }
}
