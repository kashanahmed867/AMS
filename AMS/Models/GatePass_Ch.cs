using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AMS.Models
{
    public class GatePass_Ch
    {
        [Key]
        public int GPC_Id { get; set; }

        public int GPP_Id { get; set; }
        public virtual GatePass_Pt GatePass_Pt { get; set; }

        public int Product_Id { get; set; }
        public virtual Product Product { get; set; }

        public int GPC_Quantity { get; set; }

        public decimal GPC_Rate { get; set; }

        public string GPC_Description { get; set; }

        public int GPC_GST { get; set; }

        public decimal GPC_Amount { get; set; }

        //public int GPC_ItemCode { get; set; }

        public string GPC_Unit { get; set; }


    }
}