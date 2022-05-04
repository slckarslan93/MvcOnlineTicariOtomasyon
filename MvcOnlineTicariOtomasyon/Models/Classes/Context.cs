using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class Context:DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<CurrentAccount> CurrentAccounts { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<BillsItems> BillsItems { get; set; }
        public DbSet<Bills> Bills { get; set; }
        public DbSet<Expenses> Expenses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Personal> Personals { get; set; }
        public DbSet<SalesTransactions> SalesTransactions { get; set; }
        public DbSet<Product> Products { get; set; }


    }
}