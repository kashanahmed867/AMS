using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AMS.Models
{
    public class PurchaseOrder_Pt
    {
        [Key]
        public int PO_Id { get; set; }

        public int POP_TotalQuantity { get; set; }

        public decimal POP_TotalAmount { get; set; }

        public decimal POP_TotalPaid { get; set; }

        public DateTime POP_Date { get; set; }

        public DateTime POP_ModificationDate { get; set; }

        public decimal POP_Charges { get; set; }

        public int POP_TaxPercent { get; set; }

        public decimal POP_TaxAmount { get; set; }

        public string POP_PO { get; set; }

        public int Vendor_Id { get; set; }
        public virtual Vendor Vendor { get; set; }
    }
}