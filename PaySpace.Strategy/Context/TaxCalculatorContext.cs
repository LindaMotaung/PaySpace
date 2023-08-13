using PaySpace.Strategy.Strategy;

namespace PaySpace.Strategy.Context
{
    public class TaxCalculatorContext
    {
        private  TaxCalculatorStrategy _taxCalculatorStrategy;

        public void TaxCalculator(TaxCalculatorStrategy taxCalculatorStrategy)
        {
            this._taxCalculatorStrategy = taxCalculatorStrategy;
        }

        public int ContextInterface(int income)
        {
            return _taxCalculatorStrategy.TaxCalculator(income);
        }
    }
}
