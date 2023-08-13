using System;
using NUnit.Framework;
using PaySpace.Strategy.ConcreteStrategy;

namespace PaySpace.Tests.Strategy
{
    [TestFixture]
    public class FlatValueTaxCalculatorTests
    {
        private FlatValueTaxCalculator _flatValueTaxCalculator;
        private int _nettPay;

        [SetUp]
        public void Setup()
        {
            _flatValueTaxCalculator = new FlatValueTaxCalculator();
        }

        /// <summary>
        /// Calculating nett pay for an income of 10000.
        /// </summary>
        [Test]
        public void CalculateNettPay_Income10000_ReturnsNettPay8500()
        {
            _nettPay = _flatValueTaxCalculator.TaxCalculator(10000);
            Assert.AreEqual(8500, _nettPay);
        }

        /// <summary>
        /// Calculating nett pay for an income of 200.
        /// </summary>
        [Test]
        public void CalculateNettPay_Income200_ReturnsNettPay190()
        {
            _nettPay = _flatValueTaxCalculator.TaxCalculator(200);
            Assert.AreEqual(190, _nettPay);
        }

        /// <summary>
        /// Calculating nett pay for an income of 199999.
        /// </summary>
        [Test]
        public void CalculateNettPay_Income199999_ReturnsNettPay189999()
        { 
            _nettPay = _flatValueTaxCalculator.TaxCalculator(199999);
            Assert.AreEqual(190000, _nettPay);
        }

        /// <summary>
        /// Testing that an exception is thrown when income is exactly 200000.
        /// </summary>
        [Test]
        public void CalculateNettPay_Income200000_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => _flatValueTaxCalculator.TaxCalculator(200000));
        }

        /// <summary>
        /// Testing that an exception is thrown when income is negative.
        /// </summary>
        [Test]
        public void CalculateNettPay_NegativeIncome_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => _flatValueTaxCalculator.TaxCalculator(-500));
        }

        /// <summary>
        /// Testing that an exception is thrown when income is out of the supported range.
        /// </summary>
        [Test]
        public void CalculateNettPay_IncomeOutOfRange_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => _flatValueTaxCalculator.TaxCalculator(300000));
        }
    }
}
