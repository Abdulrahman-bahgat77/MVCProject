using Demo.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Context
{
   public class MvcDBContext : DbContext
    {
        public MvcDBContext(DbContextOptions<MvcDBContext> options):base(options)
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // optionsBuilder.UseSqlServer("Server=.;Database=MvcApp;TrustedConnection=true;MultipleActiveResultSets=true");
           // optionsBuilder.UseSqlServer("Server=.;Database=MvcApp;TrustedConnection=true");
           
        }
        public DbSet<Department> Departments { get; set; }
    }
}
