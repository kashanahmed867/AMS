using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AMS.Models
{
    public class Invoice
    {
        [Key]
        public int Invoice_Id { get; set; }

        public int Invoice_No { get; set; }

        public string Invoice_Type { get; set; }

        public int SalePurchase_Id { get; set; }

        public bool Invoice_Status { get; set; }

        public DateTime Invoice_Date { get; set; }

    }
}