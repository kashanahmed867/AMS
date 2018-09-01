using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AMS.Models
{
    public class Vendor
    {
        [Key]
        public int Vendor_Id { get; set; }

        public int Id { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        public string Vendor_Name { get; set; }

        public string Vendor_MobileNo { get; set; }

        public string Vendor_Address { get; set; }

        public int Vendor_Remaining { get; set; }

        public bool Vendor_Status { get; set; }

        public string Vendor_NTN { get; set; }

        public string Vendor_Company { get; set; }

        public DateTime Vendor_Date { get; set; }




    }
}