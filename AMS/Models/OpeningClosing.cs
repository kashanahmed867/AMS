using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AMS.Models
{
    public class OpeningClosing
    {
        [Key]
        public int OpeningClosing_Id { get; set; }

        public int OpeningClosing_OpeningBalance { get; set; }

        public int OpeningClosing_ClosingBalance { get; set; }

        public bool OpeningClosing_IsClosed { get; set; }

        public DateTime OpeningClosing_Date { get; set; }

        public bool OpeningClosing_Status { get; set; }

        
    }
}