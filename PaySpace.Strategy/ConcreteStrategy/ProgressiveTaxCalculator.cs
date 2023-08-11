using System;
using PaySpace.Strategy.Strategy;

namespace PaySpace.Strategy.ConcreteStrategy
{
    public class ProgressiveTaxCalculator : TaxCalculatorStrategy
    {
        public override int TaxCalculator(int income)
        {
            if (income < 0)
            {
                throw new ArgumentException("Income cannot be negative");
            }

            var taxBrackets = new[]
            {
                (8350, 0.10),
                (33950, 0.15),
                (82250, 0.25),
                (171550, 0.28),
                (372950, 0.33),
                (int.MaxValue, 0.35)
            };

            var taxRate = 0.0;
            foreach (var (upperLimit, rate) in taxBrackets)
            {
                if (income > upperLimit) continue;
                taxRate = rate;
                break;
            }

            var taxAmount = income * taxRate;
            var nettPay = income - (int)taxAmount;

            return nettPay;
        }
    }
}
