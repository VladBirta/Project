using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project.Models;
using Project.Models;

namespace Project.Data
{
    public class ProjectContext : DbContext
    {
        public ProjectContext (DbContextOptions<ProjectContext> options)
            : base(options)
        {
        }

        public DbSet<Project.Models.Education> Education { get; set; }

        public DbSet<Project.Models.Funerals> Funerals { get; set; }

        public DbSet<Project.Models.Politics> Politics { get; set; }

        public DbSet<Project.Models.Sports> Sports { get; set; }

        public DbSet<Project.Models.Environmental> Environment { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Project.Models.Education>().HasData(new Project.Models.Education() { ID = new Guid("57EA92FF-5AC7-4F49-B327-08AA85AC132C"), EducationTitle = "Nvidia GTX1650", EducationContent = "Multe-s", PublicationDate = new DateTime(2021, 01, 01) });
        }
    }
}
