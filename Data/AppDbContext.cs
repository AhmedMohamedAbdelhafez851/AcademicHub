﻿using AcademifyHub.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using  AcademifyHub.Data.Config; 

namespace AcademifyHub.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
            
        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Office> Offices { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Participant> Particpants { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Review> Reviews { get; set; }

        public DbSet<MultipleChoiceExam> MultipleChoiceExams { get; set; }      
        public DbSet<WrittenExam> WrittenExams { get; set; }    
        public DbSet<IntrviewExam> IntrviewExams { get; set; }  
        public DbSet<TrueAndFalse> TrueAndFalses { get; set; }


        protected override void ConfigureConventions(ModelConfigurationBuilder builder)
        {
            base.ConfigureConventions(builder);
            builder.Properties<DateOnly>()
                .HaveConversion<AcademifyHub.Config.DateOnlyConverter>()
                .HaveColumnType("date");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //var config = new ConfigurationBuilder().AddJsonFile("appsettings.json")
            //    .Build();

            //var connectionString = config.GetSection("constr").Value;

            //optionsBuilder.UseSqlServer(connectionString,
            //    o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery))
            //    .LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // modelBuilder.ApplyConfiguration(new CourseConfiguration()); // not best practice

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
