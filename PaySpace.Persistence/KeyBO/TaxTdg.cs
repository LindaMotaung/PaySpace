using System.Linq;
using PaySpace.BusinessLogic.KeyBO;
using PaySpace.BusinessLogic.Persistence.KeyBO;
using PaySpace.DataLayer.Data;
using PaySpace.DataLayer.Entities;
using PaySpace.Logging.Logging;
using PaySpace.SeriLog;

namespace PaySpace.Persistence.KeyBO
{
    public class TaxTdg : ITaxTdg
    {
        public void Insert(TaxBO taxBO)
        {
            using var dbContext = new PaySpaceContext();
            var newTaxCalculation = new TaxCalculator()
            {
                PostalCodeId = taxBO.PostalCodeId,
                Income = taxBO.Income,
                Tax = taxBO.Tax,
                NettPay = taxBO.NettPay,
                CreatedOn = taxBO.CreatedOn
            };

            var existingPostalCode = dbContext.PostalCode.ToList();
            var existingPCode = existingPostalCode.FirstOrDefault(d => d.Code == "7441");

            if (existingPCode != null)
            {
                newTaxCalculation.PostalCode = existingPCode;
            }

            dbContext.TaxCalculator.Add(newTaxCalculation);
            dbContext.SaveChanges();

            LoggerProvider.Log.Information("Tax calculation done successfully.");
        }
    }
}
