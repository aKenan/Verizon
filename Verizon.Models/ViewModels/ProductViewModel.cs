using System;
using System.Collections.Generic;
using System.Text;
using Verizon.Models.DbModels;
using Verizon.Models.Helpers;

namespace Verizon.Models.ViewModels
{
    public class ProductViewModel
    {
        public ProductViewModel()
        {

        }
        public ProductViewModel(Product product, double annualConsumption)
        {
            Name = product.Name;
            AnnualCosts = product.CalculateAnnualCosts(annualConsumption);
        }
        public string Name { get; set; }
        public double AnnualCosts { get; set; }
        
    }

}
