// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace FinanceTrackerLibrary.Models
{
    public partial class DepotBonds
    {
        public int Did { get; set; }
        public int Seid { get; set; }
        public int? Amount { get; set; }

        public virtual Depot DidNavigation { get; set; }
        public virtual Bonds Se { get; set; }
    }
}