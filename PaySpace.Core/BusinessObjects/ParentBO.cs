namespace PaySpace.Core.BusinessObjects
{
    public abstract class ParentBO
    {
        /// <summary>
        /// Stores the business object to the db
        /// </summary>
        protected abstract void DoSave();
    }
}
