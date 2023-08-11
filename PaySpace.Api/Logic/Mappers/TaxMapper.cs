using System;
using PaySpace.BusinessLogic.KeyBO;
using PaySpace.BusinessLogic.TransferObjects;

namespace PaySpace.Api.Logic.Mappers
{
    public class TaxMapper
    {
        /// <summary>
        /// Maps a TO into a BO
        /// </summary>
        /// <param name="taxTO"></param>
        /// <param name="taxBO"></param>
        /// <returns></returns>
        public TaxBO MapToBo(TaxTO taxTO, TaxBO taxBO)
        {
            if (taxTO == null) throw new ArgumentNullException("TaxTO");
            if (taxBO == null) throw new ArgumentNullException("TaxBO");

            taxBO.Income = taxTO.Income;
            return taxBO;
        }
    }
}
