using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AMS.Models
{
    public class CategorySub
    {

        [Key]
        public int CategorySub_Id { get; set; }

        [Required]
        public int Category_Id { get; set; }
        public virtual Category Category { get; set; }

        [Required]
        public string CategorySub_Title { get; set; }

        [Required]
        public string CategorySub_Code { get; set; }

        public string CategorySub_Description { get; set; }

        public bool CategorySub_Status { get; set; }


    }
}