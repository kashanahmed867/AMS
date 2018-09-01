using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AMS.Models
{
    public class Transaction
    {
        [Key]
        public int Transaction_Id { get; set; }

        public virtual OpeningClosing OpeningClosing { get; set; }
        public int OpeningClosing_Id { get; set; }

        public int Transaction_ItemId { get; set; }

        public string Transaction_ItemType { get; set; }

        public string Transaction_Description { get; set; }

        public decimal Transaction_Debit { get; set; }

        public decimal Transaction_Credit { get; set; }

        public bool Transaction_IsCash { get; set; }

        public string Transaction_BankAccountNo { get; set; }

        public int Transaction_CheckBookNo { get; set; }

        public DateTime Transaction_Date { get; set; }

        public bool Transaction_Status { get; set; }



    }
}