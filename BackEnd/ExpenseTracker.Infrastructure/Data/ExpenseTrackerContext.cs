using ExpenseTracker.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Infrastructure.Data
{
    public class ExpenseTrackerContext : DbContext
    {
        public ExpenseTrackerContext(DbContextOptions<ExpenseTrackerContext> options) : base(options) 
        {     
        }
        public DbSet<Users> Users { get; set; }
        public DbSet<Expense> Expense { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Budget> Budget { get; set; }
        //public DbSet<CustomCategory> CustomCategory { get; set; }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //  modelBuilder.Entity<Expense>()
        //        .HasOne(e=>e.User)
        //        .WithMany()
        //        .HasForeignKey(x=>x.User)
        //        .OnDelete(DeleteBehavior.Cascade);

        //}
    }
}
