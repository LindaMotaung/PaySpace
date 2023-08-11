using PaySpace.Logging.Logging;
using PaySpace.SeriLog;

namespace PaySpace.Strategy.Strategy
{
    public abstract class TaxCalculatorStrategy
    {
        public virtual int TaxCalculator(int income)
        {
            if (income < 0)
            {
                LoggerProvider.Log.Error("Invalid income. Please provide a valid input");
                return 0; 
            }

            const double taxRate = 0.175; // 17.5% tax rate
            var taxAmount = income * taxRate;
            var nettPay = income - (int)taxAmount;

            return nettPay;
        }
    }
}
