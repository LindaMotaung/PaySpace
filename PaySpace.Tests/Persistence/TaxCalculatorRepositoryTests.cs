using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using PaySpace.BusinessLogic.KeyBO;
using PaySpace.BusinessLogic.Persistence.KeyBO;
using PaySpace.DataLayer.Data;
using PaySpace.Persistence.KeyBO;

namespace PaySpace.Tests.Persistence
{
    [TestFixture]
    public class TaxCalculatorRepositoryTests
    {
        private DbContextOptions<PaySpaceContext> _dbContextOptions;
        private ITaxTdg _taxTdg;

        [SetUp]
        public void Setup()
        {
            _taxTdg = new TaxTdg();
            _dbContextOptions = new DbContextOptionsBuilder<PaySpaceContext>()
                .UseInMemoryDatabase(databaseName: "PaySpace")
                .Options;
        }

        [Test]
        public void When_InsertTaxCalculation_ShouldAddTaxCalculationRecordToDatabase()
        {
            // Arrange
            using var dbContext = new PaySpaceContext(_dbContextOptions);
            using var dbContextExtensions = new PaySpaceContextExtensions();

            //var newTax = new TaxBO
            //{
            //    Id=1,
            //    PostalCodeId = 1,
            //    Income = 4000,
            //    Tax = 400,
            //    NettPay = 3600,
            //    CreatedOn = DateTime.Now
            //};

            var newTax = new TaxBO
            {
                Id = 4,
                PostalCodeId = 1,
                Income = 4000,
                Tax = 400,
                NettPay = 3600,
                CreatedOn = DateTime.Now
            };


            // Act
            _taxTdg.Insert(newTax);

            // Assert
            var result = dbContextExtensions.TaxCalculator.ToList();
            var retrieveTaxRecord = dbContextExtensions.TaxCalculator.FirstOrDefault(x => x.Id == newTax.Id);
            Assert.IsNotNull(retrieveTaxRecord);
            Assert.AreEqual(newTax.Income, retrieveTaxRecord.Income);
            Assert.AreEqual(newTax.Tax, retrieveTaxRecord.Tax);
            Assert.AreEqual(newTax.NettPay, retrieveTaxRecord.NettPay);
        }
    }
}
