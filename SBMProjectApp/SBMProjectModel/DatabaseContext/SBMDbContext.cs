using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SBMProjectModel.Models;

namespace SBMProjectModel.DatabaseContext
{
    public partial class SBMDbContext : DbContext
    {
        public SBMDbContext() : base("name=SBMDbContext")
        {

        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Login> Logins { get; set; }
    }
}
