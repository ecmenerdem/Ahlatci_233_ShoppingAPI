using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ShoppingAPI.DAL.Concrete.EntityFramework.Context
{
    public class ShoppingContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    "data source=.; initial catalog=Shopping233DB; integrated security=True; TrustServerCertificate=true");
            }
            base.OnConfiguring(optionsBuilder);
        }
    }
}
