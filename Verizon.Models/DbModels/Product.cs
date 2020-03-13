using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Verizon.BLL.Enums;

namespace Verizon.Models.DbModels
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// Base cost (€)
        /// </summary>
        public double BaseCost { get; set; }
        /// <summary>
        /// Base cost type (per Month, per Year)
        /// </summary>
        public BaseCostType BaseCostType { get; set; }
        /// <summary>
        /// Consumption cost (€)
        /// </summary>
        public double ConsumptionCost { get; set; }
        /// <summary>
        /// Free consumption per year (kwh/year)
        /// </summary>
        public double UnpayedConsumption { get; set; }
        public bool Active { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
