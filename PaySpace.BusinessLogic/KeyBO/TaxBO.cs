using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace PaySpace.BusinessLogic.KeyBO
{
    public class TaxBO
    {
        public int Id { get; set; }
        public int PostalCodeId { get; set; }
        public int Income { get; set; }
        public int? Tax { get; set; }
        public int? NettPay { get; set; }
        public DateTime? CreatedOn { get; set; }

        public static TaxBO Create(int income)
        {
            return new TaxBO();
        }
    }
}
