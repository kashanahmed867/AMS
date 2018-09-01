using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AMS.Models
{
    public class Category
    {
        [Key]
        public int Category_Id { get; set; }

        [Required]    
        public string Category_Title { get; set; }

        [Required]
        public string Category_Code { get; set; }

        public string Category_Description { get; set; }

        public bool Category_Status { get; set; }
    }
}