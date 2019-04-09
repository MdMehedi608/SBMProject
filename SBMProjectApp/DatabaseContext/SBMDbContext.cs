using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SBMProjectModels.Models;

namespace SBMProjectModels.DatabaseContext
{
    public partial class SBMDbContext :DbContext
    {
        public SBMDbContext() : base("name=SBMDbContext")
        {

        }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Login> Logins { get; set; }
    }
}
