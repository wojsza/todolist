using Microsoft.EntityFrameworkCore;
using System;
using TodoDataAccess.Models;

namespace TodoDataAccess
{
    public class TodoDbContext : DbContext
    {
        public DbSet<Activity> Activieties { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string sqlitePath = $@"{AppDomain.CurrentDomain.BaseDirectory}\todo.db";
            optionsBuilder.UseSqlite($@"Data Source={sqlitePath}");
        }
    }
}
