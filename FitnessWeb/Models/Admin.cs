﻿using FitnessWeb.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.Core.Models
{
    public class Admin : IdentityUser
    {
        public int Id { get; set; }
    }
}
