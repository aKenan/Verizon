using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verizon.Models.DbModels;

namespace Verizon.Services
{
    public class ProductService
    {
        private VerizonDbContext _db;

        public ProductService(VerizonDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Product> GetProducts()
        {
            return _db.Products.ToList();
        }
    }
}
