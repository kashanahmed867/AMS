using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AMS.Models
{
    public class GatePass_Pt
    {
        [Key]
        public int GPP_Id { get; set; }

        public int Vendor_Id { get; set; }
        public virtual Vendor Vendor { get; set; }

        public int GPP_TotalQuantity { get; set; }

        public decimal GPP_TotalAmount { get; set; }

        public decimal GPP_TotalPaid { get; set; }

        public DateTime GPP_Date { get; set; }

        public DateTime GPP_ModificationDate { get; set; }

        public decimal GPP_Charges { get; set; }

        public int GPP_TaxPercent { get; set; }

        public decimal GPP_TaxAmount { get; set; }

        public string GPP_No { get; set; }

        public bool GPP_Status { get; set; }


    }
}