using System;
using PaySpace.Api.Logic.Mappers;
using PaySpace.BusinessLogic.KeyBO;
using PaySpace.BusinessLogic.TransferObjects;

namespace PaySpace.Api.Logic.Strategies
{
    public class TaxFacade
    {
        private static TaxFacade instance;
        public static TaxFacade Instance => instance ??= new TaxFacade();
        private static TaxMapper taxMapper;

        public TaxFacade()
        {
            taxMapper = new TaxMapper();
        }

        public long CalculateTax(TaxTO taxTO)
        {
            if (taxTO == null)
            {
                throw new ArgumentException("Tax");
            }

            var income = taxTO.Income;
            var taxBO = TaxBO.Create(income);

            taxBO = taxMapper.MapToBo(taxTO, taxBO);

            SaveTax(taxBO);

            return taxBO.Id;
        }

        private static void SaveTax(TaxBO tax)
        {
            tax?.Save();
        }
    }
}
