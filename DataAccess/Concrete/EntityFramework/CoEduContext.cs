using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class CoEduContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=CoEduDb;Trusted_Connection=true");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserImage> UserImages { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<TrainerImage> TrainerImages { get; set; }
        public DbSet<SportEdu> SportEdus { get; set; }
        public DbSet<PerDevEdu> PerDevEdus { get; set; }
        public DbSet<HSchoolEdu> HSchoolEdus { get; set; }
        public DbSet<FormOfEdu> FormOfEdus { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<TrainerOperationClaim> TrainerOperationClaims { get; set; }
    }
}
