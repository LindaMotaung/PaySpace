﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace PaySpace.DataLayer.Entities
{
    public partial class TaxCalculator
    {
        public int Id { get; set; }
        public int PostalCodeId { get; set; }
        public int Income { get; set; }
        public int? Tax { get; set; }
        public int? NettPay { get; set; }

        public virtual PostalCode PostalCode { get; set; }
    }
}