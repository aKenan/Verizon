using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Verizon.Models.DbModels
{
    // ****** FAKE DB *******
    public class VerizonDbContext : DbContext
    {
        public VerizonDbContext(DbContextOptions<VerizonDbContext> options) : base(options)
        {
            LoadData();
        }
        
        public DbSet<Product> Products { get; set; }

        private void LoadData()
        {
            if (!Products.Any())
            {
                Products.AddRange
                   (
                   new Product() { Id = 0, Name = "Basic Electricity tariff", BaseCost = 5, BaseCostType = BLL.Enums.BaseCostType.Monthly, ConsumptionCost = 0.22, UnpayedConsumption = 0, Active = true, DateCreated = DateTime.Now },
                   new Product() { Id = 0, Name = "Packaged tariff", BaseCost = 800, BaseCostType = BLL.Enums.BaseCostType.Yearly, ConsumptionCost = 0.3, UnpayedConsumption = 4000, Active = true, DateCreated = DateTime.Now }
                   );

                this.SaveChanges();
            }
               
        }
    }
}
