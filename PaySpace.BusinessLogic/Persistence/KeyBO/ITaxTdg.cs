using PaySpace.BusinessLogic.KeyBO;

namespace PaySpace.BusinessLogic.Persistence.KeyBO
{
    /// <summary>
    /// Interface of the TableDataGateways for TaxBO (Tax Business Object).
    /// </summary>
    public interface ITaxTdg
    {
        /// <summary>
        /// Inserts the data record into the db
        /// </summary>
        /// <param name="iraBO"></param>
        void Insert(TaxBO taxBO);
    }
}
