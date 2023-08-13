using System;
using System.Collections.Generic;
using System.Text;
using PaySpace.BusinessLogic.KeyBO;

namespace PaySpace.BusinessLogic.Persistence.KeyBO
{
    /// <summary>
    /// Interface of the TableDataGateways for TaxBO (Tax Business Object).
    /// </summary>
    public interface ITaxTdg
    {
        /// <summary>
        /// Method checks whether the specific record exists in the db
        /// </summary>
        /// <param name="ctx"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        bool ExistsRecord(int id);

        /// <summary>
        /// Loads the BO with the given Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TaxBO Load(int id);

        /// <summary>
        /// Loads all BOs
        /// </summary>
        /// <returns></returns>
        IList<TaxBO> LoadAll();

        /// <summary>
        /// Updates the data record in the db
        /// </summary>
        /// <param name="iraBO"></param>
        void Update(TaxBO iraBO);

        /// <summary>
        /// Inserts the data record into the db
        /// </summary>
        /// <param name="iraBO"></param>
        void Insert(TaxBO iraBO);

        /// <summary>
        /// Deletes the data record from the DB
        /// </summary>
        /// <param name="iraBO"></param>
        void Delete(TaxBO iraBO);
    }
}
