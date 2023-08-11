using PaySpace.Strategy.Strategy;

namespace PaySpace.Strategy.Context
{
    public class TaxCalculatorContext
    {
        private readonly TaxCalculatorStrategy _taxCalculatorStrategy;

        public TaxCalculatorContext(TaxCalculatorStrategy taxCalculatorStrategy)
        {
            this._taxCalculatorStrategy = taxCalculatorStrategy;
        }

        public int ContextInterface(int income)
        {
            return _taxCalculatorStrategy.TaxCalculator(income);
        }
    }
}
