using System;
using PaySpace.Strategy.Strategy;

namespace PaySpace.Strategy.ConcreteStrategy
{
    public class FlatValueTaxCalculator : TaxCalculatorStrategy
    {
        public override int TaxCalculator(int income)
        {
            if (income < 0)
            {
                throw new ArgumentException("Income cannot be negative");
            }

            double taxRate;

            if (income == 10000)
            {
                taxRate = 0.15;
            }
            else if (income < 200000)
            {
                taxRate = 0.05; // 5%
            }
            else
            {
                throw new ArgumentException("Income out of supported range");
            }

            var taxAmount = income * taxRate;
            var nettPay = income - (int)taxAmount;

            return nettPay;
        }
    }
}
