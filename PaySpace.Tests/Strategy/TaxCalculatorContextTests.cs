using NUnit.Framework;
using PaySpace.Strategy.ConcreteStrategy;
using PaySpace.Strategy.Context;

namespace PaySpace.Tests.Strategy
{
    [TestFixture]
    public class TaxCalculatorContextTests
    {
        private TaxCalculatorContext _taxCalculatorContext;
        private int _nettPay;

        [SetUp]
        public void Setup()
        {
            _taxCalculatorContext = new TaxCalculatorContext();
        }

        [Test]
        public void CalculateTax_FlatRate_ReturnsCorrectNettIncome()
        {
            _taxCalculatorContext.TaxCalculator(new FlatRateTaxCalculator());
            _nettPay = _taxCalculatorContext.ContextInterface(10000);
            Assert.AreEqual(8250, _nettPay);
        }

        [Test]
        public void CalculateTax_FlatValue_ReturnsCorrectNettIncome()
        {
            _taxCalculatorContext.TaxCalculator(new FlatValueTaxCalculator());
            _nettPay = _taxCalculatorContext.ContextInterface(10000);
            Assert.AreEqual(8500, _nettPay);
        }

        [Test]
        public void CalculateTax_Progressive_ReturnsCorrectNettIncome()
        {
            _taxCalculatorContext.TaxCalculator(new ProgressiveTaxCalculator());
            _nettPay = _taxCalculatorContext.ContextInterface(50000);
            Assert.AreEqual(37500, _nettPay);
        }
    }
}
