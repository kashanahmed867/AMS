using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AMS.Models
{
    public class SaleOrder_Pt
    {
        [Key]
        public int SOP_Id { get; set; }

        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        public int SOP_TotalQuantity { get; set; }

        public decimal SOP_TotalAmount { get; set; }

        public decimal SOP_TotalReceived { get; set; }

        public DateTime SOP_Date { get; set; }

        public DateTime SOP_ModificationDate { get; set; }

        public decimal SOP_Charges { get; set; }

        public int SOP_TaxPercent { get; set; }

        public decimal SOP_TaxAmount { get; set; }

        public string SOP_SO { get; set; }




    }
}