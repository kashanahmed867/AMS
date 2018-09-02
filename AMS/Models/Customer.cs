using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AMS.Models
{
    public class Customer
    {
        [Key]
        public int Customer_Id { get; set; }

        public string Id { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        public string Customer_Name { get; set; }

        public string Customer_MobileNo { get; set; }

        public string Customer_Address { get; set; }

        public int Customer_Remaining { get; set; }

        public bool Customer_Status { get; set; }

        public string Customer_NTN { get; set; }

        public string Customer_Company { get; set; }

        public DateTime Customer_Date { get; set; }
    }
}