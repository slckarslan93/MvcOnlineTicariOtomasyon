using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class Category
    {
        [Key] //For Entity Framework CRUD operations
        public int CategoryId { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string CategoryName { get; set; }

        public ICollection<Product> Products { get; set; } //Kategoride birden fazla ürün olabileceği için bu ürünleri ICollections un içinde tutuyoruz (ilişkili tablolar)

    }
}