using System;
using System.Collections.Generic;
using System.Text;
using Verizon.Models.DbModels;

namespace Verizon.Models.Helpers
{
    public static class ProductHelper
    {
        public static double CalculateAnnualCosts(this Product product, double annualConsumation)
        {
            double baseCost = 0;

            switch (product.BaseCostType)
            {
                case BLL.Enums.BaseCostType.Monthly:
                    baseCost = product.BaseCost * 12;
                    break;
                case BLL.Enums.BaseCostType.Yearly:
                    baseCost = product.BaseCost;
                    break;
                default:
                    break;
            }

            double consumptionCosts = 0;
            double consumptionValueToCalculate = annualConsumation - product.UnpayedConsumption;

            if (annualConsumation - product.UnpayedConsumption > 0)
                consumptionCosts = consumptionValueToCalculate * product.ConsumptionCost;

            return baseCost + consumptionCosts;
        }
    }
}
