using System;
using Microsoft.EntityFrameworkCore;
using ElearningPortal.Models;
namespace ElearningPortal.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<UserData>? Users { get; set; }
        public DbSet<Course>? Courses { get; set; }
        public DbSet<Enrollment>? Enrollments { get; set; }

    }
}

