using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class Bills
    {
        [Key]
        public int BillsId { get; set; }
        [Column(TypeName = "Char")]
        [StringLength(1)]
        public string BillSerialNo { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(6)]
        public string BillOrderNo { get; set; }
        public DateTime BillDate { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(60)]
        public string TaxAdministration { get; set; }
        public DateTime Hour { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Submitter { get; set; } //teslim eden
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Receiver { get; set; } //teslim alan
        public ICollection<BillsItems> BillsItems { get; set; }
    }
}