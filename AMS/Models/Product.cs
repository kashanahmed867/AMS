using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AMS.Models
{
    public class Product
    {
        [Key]
        public int Product_Id { get; set; }

        [Required]
        public int CategorySub_Id { get; set; }
        public virtual CategorySub CategorySub { get; set; }

        public int ProductSize_Id { get; set; }
        public virtual ProductSize ProductSize { get; set; }

        [Required]
        public string Product_Title { get; set; }

        [Required]
        public string Product_Code { get; set; }

        public string Product_Description { get; set; }

        public int Product_Weight { get; set; }

        public decimal Product_Rate { get; set; }

        public bool Product_Status { get; set; }

        public string Product_Color { get; set; }

        public DateTime Product_Date { get; set; }

        public string Product_Unit { get; set; }

        public decimal Product_UnitPrice { get; set; }

        //public string Product_Varient { get; set; }
    }
}