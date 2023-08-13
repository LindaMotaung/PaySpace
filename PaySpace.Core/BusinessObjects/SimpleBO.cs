namespace PaySpace.Core.BusinessObjects
{
    /// <summary>
    /// This design accommodates the possibility of the TaxBO changing in future and allowing abstraction to more complexity
    /// </summary>
    public abstract class SimpleBO : ParentBO
    {
        /// <summary>
        ///  Stores the BO in the database.
        /// </summary>
        public virtual void Save()
        {
            DoSave();
        }
    }
}
