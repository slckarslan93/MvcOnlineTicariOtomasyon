using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    //Giderler
    public class Expenses
    {
        [Key]
        public int ExpensesId { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string Explanation { get; set; } //Açıklama
        public DateTime Date { get; set; }
        public decimal Price { get; set; }


    }
}