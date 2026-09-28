using _1._30._26.Models;
using _1._30._26.Models.DeveloperProject;
using _1._30._26.Models.ProductsCategories;
using _1._30._26.Models.TeacherUniversity;
using _1._30._26.Models.UserEvent;
using _1._30._26.Models.YoutuberPost;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace _1._30._26.Data
{
    internal class DataContext : DbContext
    {

        public DbSet<Developer> developers { get; set; }
        public DbSet<Project> projects { get; set; }
        public DbSet<DeveloperProject> developerProjects { get; set; }

        public DbSet<Teacher> teachers { get; set; }
        public DbSet<University> universities { get; set; }
        public DbSet<TeacherUniversity> teacherUniversities { get; set; }

        public DbSet<User> users { get; set; }
        public DbSet<Event> events { get; set; }
        public DbSet<UserEvent> userEvents { get; set; }

        public DbSet<Category> categories { get; set; }
        public DbSet<Product> products { get; set; }

        public DbSet<Post> posts { get; set; }
        public DbSet<Youtuber> youtubers { get; set; }

        public DbSet<CourseStudent> courseStudents { get; set; }
        public DbSet<Student>students { get; set; }
        public DbSet<Course> courses { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\ProjectModels;Initial Catalog=ManyToMany_DB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CourseStudent>()
                .HasKey(x=> new {x.CourseId, x.StudentId});

            modelBuilder.Entity<UserEvent>()
                .HasKey(ue => new { ue.UserId, ue.EventId });
            modelBuilder.Entity<TeacherUniversity>()
                .HasKey(tu => new { tu.TeacherId, tu.UniversityId });
            modelBuilder.Entity<DeveloperProject>()
                .HasKey(dp => new { dp.DeveloperId, dp.ProjectId });

        }
     

    }
}
