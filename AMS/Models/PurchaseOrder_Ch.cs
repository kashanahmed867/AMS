using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AMS.Models
{
    public class PurchaseOrder_Ch
    {
        [Key]
        public int POC_Id { get; set; }

        public int POP_Id { get; set; }
        public virtual PurchaseOrder_Pt PurchaseOrder_Pt { get; set; }

        public int Product_Id { get; set; }
        public virtual Product Product { get; set; }

        public int POC_Quantity { get; set; }

        public decimal POC_Rate { get; set; }

        public string POC_Description { get; set; }

        public int POC_GST { get; set; }

        public decimal POC_Amount { get; set; }

        public string POC_ItemCode { get; set; }

        public string POC_Unit { get; set; }
    }
}