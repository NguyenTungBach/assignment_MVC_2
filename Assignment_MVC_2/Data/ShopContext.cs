using Assignment_MVC_2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Assignment_MVC_2.Data
{
    public class ShopContext: DbContext
    {
        public ShopContext() : base("name=AssignmentMVCString")
        {
        }

        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }
    }
}