using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class Personal
    {
        [Key]
        public int PersonalId { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string PersonalName { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string PersonalSurname { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string PersonalImage { get; set; } //Veri tabanını şişirmemek için string olarak image yolunu tutuyoruz.

        public ICollection<SalesTransactions> SalesTransactions { get; set; }

        public int Departmentid { get; set; }
        public virtual Department Department { get; set; }


    }
}