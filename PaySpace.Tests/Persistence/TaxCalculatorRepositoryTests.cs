using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using PaySpace.DataLayer.Data;
using PaySpace.DataLayer.Entities;

namespace PaySpace.Tests.Persistence
{
    [TestFixture]
    public class TaxCalculatorRepositoryTests
    {
        private DbContextOptions<PaySpaceContext> _dbContextOptions;

        [SetUp]
        public void Setup()
        {
            _dbContextOptions = new DbContextOptionsBuilder<PaySpaceContext>()
                .UseInMemoryDatabase(databaseName: "PaySpace")
                .Options;
        }

        public void When_InsertTaxCalculation_ShouldAddTaxCalculationRecordToDatabase()
        {
            // Arrange
            using (var dbContext = new PaySpaceContext(_dbContextOptions))
            {
                var newEmployee = new TaxCalculator
                {
                    PostalCodeId = 1,
                    Income = 4000,
                    Tax = 400,
                    NettPay = 3600,
                    CreatedOn = DateTime.Now
                };
            }

            // Act

            // Assert
        }
    }
}
