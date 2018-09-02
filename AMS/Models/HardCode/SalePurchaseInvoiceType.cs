using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AMS.Models.HardCode
{
    public class SalePurchaseInvoiceType
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public int GenerateInvoiceNo(string Type)
        {
            int invoiceno = 0;
            try
            {
                invoiceno = db.Invoices.Where(m => m.Invoice_Type == Type).Max(m => m.Invoice_No);
            }
            catch (Exception)
            {

            }
            return (invoiceno == 0) ? 1 : ++invoiceno;
        }
    }
}