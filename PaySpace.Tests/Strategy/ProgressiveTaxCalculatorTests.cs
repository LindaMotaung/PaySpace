using System;
using NUnit.Framework;
using PaySpace.Strategy.ConcreteStrategy;

namespace PaySpace.Tests.Strategy
{
    [TestFixture]
    public class ProgressiveTaxCalculatorTests
    {
        private ProgressiveTaxCalculator _progressiveTaxCalculator;
        private int _nettPay;

        [SetUp]
        public void Setup()
        {
            _progressiveTaxCalculator = new ProgressiveTaxCalculator();
        }

        /// <summary>
        /// Calculating nett pay for a positive income within a tax bracket.
        /// </summary>
        [Test]
        public void CalculateNettPay_PositiveIncome_ReturnsCorrectNettPay()
        {
            _nettPay = _progressiveTaxCalculator.TaxCalculator(50000);
            Assert.AreEqual(37500, _nettPay);
        }

        /// <summary>
        /// Attempting to calculate nett pay for a negative income (throws ArgumentException).
        /// </summary>
        [Test]
        public void CalculateNettPay_NegativeIncome_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => _progressiveTaxCalculator.TaxCalculator(-200));
        }

        /// <summary>
        /// Calculating nett pay for a low income within a tax bracket.
        /// </summary>
        [Test]
        public void CalculateNettPay_LowIncome_ReturnsCorrectNettPay()
        {
            _nettPay = _progressiveTaxCalculator.TaxCalculator(6000);
            Assert.AreEqual(5700, _nettPay);
        }

        /// <summary>
        /// Calculating nett pay for a medium income within a tax bracket.
        /// </summary>
        [Test]
        public void CalculateNettPay_MediumIncome_ReturnsCorrectNettPay()
        {
            _nettPay = _progressiveTaxCalculator.TaxCalculator(40000);
            Assert.AreEqual(30000, _nettPay);
        }

        /// <summary>
        /// Calculating nett pay for a high income within a tax bracket.
        /// </summary>
        [Test]
        public void CalculateNettPay_HighIncome_ReturnsCorrectNettPay()
        {
            _nettPay = _progressiveTaxCalculator.TaxCalculator(200000);
            Assert.AreEqual(126900, _nettPay);
        }

        /// <summary>
        /// Calculating nett pay for the maximum possible income (using int.MaxValue).
        /// </summary>
        [Test]
        public void CalculateNettPay_MaxIncome_ReturnsCorrectNettPay()
        {
            _nettPay = _progressiveTaxCalculator.TaxCalculator(int.MaxValue);
            Assert.AreEqual(int.MaxValue, _nettPay);
        }
    }
}
