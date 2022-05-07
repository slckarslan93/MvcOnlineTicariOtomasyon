using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class CurrentAccount //Customer Account information
    {
        [Key]
        public int CurrentAccountId { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30,ErrorMessage ="En Fazla 30 Karakter yazabilirsiniz")]
        public string CurrentAccountName { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        [Required(ErrorMessage ="Bu alanı boş geçemezsiniz!")]
        public string CurrentAccountSurname { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        public string CurrentAccountCity { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string CurrentAccountMail { get; set; }

        public bool Status { get; set; }

        public ICollection<SalesTransactions> SalesTransactions { get; set; }
    }
}