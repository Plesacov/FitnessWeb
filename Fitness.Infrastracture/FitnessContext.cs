using Fitness.Core.Models;
using FitnessWeb.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.Infrastracture
{
    public class FitnessContext : DbContext
    {
        public FitnessContext()
        {

        }

        public FitnessContext(DbContextOptions<FitnessContext> options) : base(options)
        {

        }
        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<Exercise> Exercise { get; set; }
        public virtual DbSet<FitnessProgram> FitnessProgram { get; set; }
        public virtual DbSet<FitnessTip> FitnessTip { get; set; }
        public virtual DbSet<Training> Training { get; set; }
        public virtual DbSet<PersonFitnessProgram> PersonFitnessProgram { get; set; }
        public virtual DbSet<Award> Award { get; set; }
        public virtual DbSet<Achievement> Achievement { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PersonFitnessProgram>()
                .HasOne(x => x.Person)
                .WithMany(x => x.PersonFitnessPrograms)
                .HasForeignKey(x => x.PersonId);
            modelBuilder.Entity<PersonFitnessProgram>()
                .HasOne(x => x.FitnessProgram)
                .WithMany(x => x.PersonFitnessPrograms)
                .HasForeignKey(x => x.FitnessProgramId);
            //modelBuilder.Entity<PersonFitnessProgram>()
            //    .HasKey(c => new { c.PersonId, c.FitnessProgramId });
            modelBuilder.Entity<Person>()
                .HasMany(x => x.Achievements)
                .WithOne(x => x.Person);
            modelBuilder.Entity<Training>()
                .HasMany(x => x.Exercises)
                .WithOne(x => x.Training)
                .IsRequired();
            modelBuilder.Entity<FitnessProgram>()
                .HasMany(x => x.Trainings)
                .WithOne(x => x.FitnessProgram)
                .IsRequired();
            modelBuilder.Entity<FitnessProgram>()
                .HasMany(x => x.FitnessTips)
                .WithOne(x => x.FitnessProgram);
            modelBuilder.Entity<Achievement>()
                .HasMany(x => x.Awards)
                .WithOne(x => x.Achievement)
                .IsRequired();
        }
    }
}
