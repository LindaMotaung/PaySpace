using System;

namespace PaySpace.BusinessLogic.Persistence
{
    /// <summary>
    ///  Generates TDG instances.
    /// </summary>
    public abstract class TdgFactory
    {
        private static TdgFactory instance;

        /// <summary>
        /// Returns an instance of the type TdgFactory.
        /// </summary>
        public static TdgFactory Instance
        {
            get
            {
                var type = Type.GetType("PaySpace.Persistence.TdgStrategyImpl, PaySpace.Persistence");
                return instance ??= type != null ? (TdgFactory)Activator.CreateInstance(type) : null;
            }
        }

        /// <summary>
        /// Generic method for generating TDGs
        /// </summary>
        /// <typeparam name="T">The interface type of the TDG to be generated.</typeparam>
        /// <returns>Instance of a concrete implementation of the TDG interface.</returns>
        public abstract T CreateTdg<T>();

        public abstract T CreateTdg2<T>();
    }
}
