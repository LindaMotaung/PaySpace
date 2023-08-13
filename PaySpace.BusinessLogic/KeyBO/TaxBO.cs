using System;
using PaySpace.BusinessLogic.Persistence;
using PaySpace.BusinessLogic.Persistence.KeyBO;
using PaySpace.Core.BusinessObjects;

namespace PaySpace.BusinessLogic.KeyBO
{
    public class TaxBO : SimpleBO
    {
        private static readonly ITaxTdg tdg =
            TdgFactory.Instance.CreateTdg<ITaxTdg>();

        public int Id { get; set; }
        public int PostalCodeId { get; set; }
        public int Income { get; set; }
        public int? Tax { get; set; }
        public int? NettPay { get; set; }
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Constructor to create a new instance.
        /// </summary>
        protected TaxBO(int income)
        {
            Income = income;
        }

        public static TaxBO Create(int income)
        {
            return new TaxBO(income);
        }

        protected override void DoSave()
        {
            tdg.Insert(this);
        }
    }
}
