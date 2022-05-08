using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class BillsItems
    {
        [Key]
        public int BillsItemsId { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Price { get; set; }
        public int BillsId { get; set; }
        public virtual Bills Bills { get; set; }

    }
}