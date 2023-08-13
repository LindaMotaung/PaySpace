using System;
using System.Collections.Generic;
using PaySpace.BusinessLogic.KeyBO;
using PaySpace.BusinessLogic.Persistence.KeyBO;
using PaySpace.DataLayer.Data;
using PaySpace.DataLayer.Entities;
using PaySpace.Logging.Logging;
using PaySpace.SeriLog;

namespace PaySpace.Persistence
{
    public class TaxTdg : ITaxTdg
    {
        /// <summary>
        /// Method checks whether the specific record exists in the db
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool ExistsRecord(int id)
        {
            throw new NotImplementedException();
        }

        public TaxBO Load(int id)
        {
            throw new NotImplementedException();
        }

        public IList<TaxBO> LoadAll()
        {
            throw new NotImplementedException();
        }

        public void Update(TaxBO taxBO)
        {
            throw new NotImplementedException();
        }

        public void Insert(TaxBO taxBO)
        {
            using (var dbContext = new PaySpaceContext())
            {
                var newTaxCalculation = new TaxCalculator()
                {
                    PostalCodeId = taxBO.PostalCodeId,
                    Income = taxBO.Income,
                    Tax = taxBO.Tax,
                    NettPay = taxBO.NettPay,
                    CreatedOn = taxBO.CreatedOn
                };

                dbContext.TaxCalculator.Add(newTaxCalculation);
                dbContext.SaveChanges();

                LoggerProvider.Log.Information("Tax calculation done successfully.");
            }
        }

        public void Delete(TaxBO taxBO)
        {
            throw new NotImplementedException();
        }
    }
}
