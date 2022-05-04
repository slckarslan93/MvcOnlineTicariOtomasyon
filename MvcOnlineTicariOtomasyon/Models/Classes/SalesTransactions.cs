using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class SalesTransactions
    {
        [Key]
        public int SalesId { get; set; }
       
        public DateTime Date { get; set; }
        public int Unit { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }

        public int ProductId { get; set; }
        public int CurrentAccountId { get; set; }
        public int PersonalId { get; set; }

        public virtual Product Product { get; set; }
        public virtual CurrentAccount CurrentAccount { get; set; }
        public virtual Personal Personal { get; set; }
    }
}