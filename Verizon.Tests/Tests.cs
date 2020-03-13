using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using System;
using System.Linq;
using Verizon.Models.DbModels;
using Verizon.Models.Helpers;
using Verizon.Models.ViewModels;
using Xunit;

namespace Verizon.Tests
{
    public class Tests
    {
        private VerizonDbContext _db;
        DbContextOptions<VerizonDbContext> options;
        DbContextOptionsBuilder<VerizonDbContext> builder = new DbContextOptionsBuilder<VerizonDbContext>();

        Product productBasic = new Product() { BaseCost = 5, BaseCostType = BLL.Enums.BaseCostType.Monthly, ConsumptionCost = 0.22, UnpayedConsumption = 0 };
        Product productPackaged = new Product() { BaseCost = 800, BaseCostType = BLL.Enums.BaseCostType.Yearly, ConsumptionCost = 0.30, UnpayedConsumption = 4000 };
        public Tests()
        {
            
            builder.UseInMemoryDatabase(databaseName: "VerizonDb");
            options = builder.Options;
            _db = new VerizonDbContext(options);
        }
        [Fact]
        public void HasProducts()
        {
            Assert.True(_db.Products.ToList().Count > 0);
        }

        [Fact]
        public void BaseCostTypeCheck()
        {
            //contains any products with base cost type that is not monthly or yearly - base costs calculation would not be exact
            Assert.DoesNotContain(_db.Products, p => p.BaseCostType != BLL.Enums.BaseCostType.Monthly && p.BaseCostType != BLL.Enums.BaseCostType.Yearly);
        }

        [Fact]
        public void Check3500Basic()
        {
            Assert.Equal(830, productBasic.CalculateAnnualCosts(3500));
        }

        [Fact]
        public void Check3500Packaged()
        {
            Assert.Equal(800, productPackaged.CalculateAnnualCosts(3500));
        }

        [Fact]
        public void Check4500Basic()
        {
            Assert.Equal(1050, productBasic.CalculateAnnualCosts(4500));
        }

        [Fact]
        public void Check4500Packaged()
        {
            Assert.Equal(950, productPackaged.CalculateAnnualCosts(4500));
        }

        [Fact]
        public void Check6000Basic()
        {
            Assert.Equal(1380, productBasic.CalculateAnnualCosts(6000));
        }

        [Fact]
        public void Check6000Packaged()
        {
            Assert.Equal(1400, productPackaged.CalculateAnnualCosts(6000));
        }
    }
}
