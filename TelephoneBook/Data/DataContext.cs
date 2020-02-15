using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TelephoneBook.Models;

namespace TelephoneBook.Data
{
    public class DataContext : DbContext
    {
        // veritabanı ile modellerimin bağlandığı ortam.
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Admin> Admins { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasKey(x => new { x.id });
            modelBuilder.Entity<Contact>().HasKey(x => new { x.id });
            modelBuilder.Entity<Department>().HasKey(x => new { x.id });
            modelBuilder.Entity<Manager>().HasKey(x => new { x.id });
            modelBuilder.Entity<Admin>().HasKey(x => new { x.id });
        }
    }
}
