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
        public DbSet<UserModel>? UserModels { get; set; }
        public DbSet<Course>? Courses { get; set; }
    }
}

