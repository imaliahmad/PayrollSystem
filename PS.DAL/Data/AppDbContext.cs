using Microsoft.EntityFrameworkCore;
using PS.BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.DAL.Data
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Server=MEHROZQAZI-PC\SQLEXPRESS;Database=PayrollSystemA;Trusted_Connection=True");
        }

        //Db Set

        public DbSet<Department> Department { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Leave> Leave { get; set; }
        public DbSet<Salary> Salary { get; set; }
        public DbSet<Attendence> Attendence { get; set; }
    }
}
