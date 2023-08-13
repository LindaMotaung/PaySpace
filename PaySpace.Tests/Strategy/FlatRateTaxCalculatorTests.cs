using NUnit.Framework;
using PaySpace.Strategy.ConcreteStrategy;

namespace PaySpace.Tests.Strategy
{
    [TestFixture]
    public class FlatRateTaxCalculatorTests 
    {
        private FlatRateTaxCalculator _flatRateTaxCalculatorTests;
        private int _nettPay;

        [SetUp]
        public void Setup()
        {
            _flatRateTaxCalculatorTests = new FlatRateTaxCalculator();
        }

        /// <summary>
        /// Calculating nett pay for a positive income.
        /// </summary>
        [Test]
        public void CalculateNettPay_PositiveIncome_ReturnsCorrectNettPay()
        {
            _nettPay = _flatRateTaxCalculatorTests.TaxCalculator(10000);
            Assert.AreEqual(8250, _nettPay);
        }

        /// <summary>
        /// Calculating nett pay for a negative income (returns 0 as specified in the method).
        /// </summary>
        [Test]
        public void CalculateNettPay_NegativeIncome_ReturnsZero()
        {
            _nettPay = _flatRateTaxCalculatorTests.TaxCalculator(-200);
            Assert.AreEqual(0, _nettPay);
        }

        /// <summary>
        /// Calculating nett pay for an income of zero (    returns 0 as specified in the method).
        /// </summary>
        [Test]
        public void CalculateNettPay_ZeroIncome_ReturnsZero()
        {
            _nettPay = _flatRateTaxCalculatorTests.TaxCalculator(0);
            Assert.AreEqual(0, _nettPay);
        }

        /// <summary>
        /// Calculating nett pay for an income within a reasonable range.
        /// </summary>
        [Test]
        public void CalculateNettPay_IncomeOutOfRange_ReturnsCorrectNettPay()
        {
            _nettPay = _flatRateTaxCalculatorTests.TaxCalculator(5000);
            Assert.AreEqual(4125, _nettPay);
        }
    }
}
