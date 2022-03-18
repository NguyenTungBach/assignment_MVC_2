namespace Assignment_MVC_2.Migrations
{
    using Assignment_MVC_2.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Assignment_MVC_2.Data.ShopContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Assignment_MVC_2.Data.ShopContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            //var products = new List<Product>
            //{
            //    new Product { ProductName = "T-shirt kid UNIQLO",   Price = 100000, CategoryId=1 },
            //    new Product { ProductName = "Jeans kid UNIQLO", Price =200000, CategoryId=2 },
            //    new Product { ProductName = "Shoes kid Dolce & Gabbana",   Price = 60000, CategoryId=3},
            //    new Product { ProductName = "Suit God Of War",    Price = 900000, CategoryId=4},
            //};
            //products.ForEach(s => context.Product.AddOrUpdate(s));

            //var categories = new List<Category>
            //{
            //    new Category { CategoryName = "T-shirt" },
            //    new Category { CategoryName = "Jeans"},
            //    new Category { CategoryName = "Shoes"},
            //    new Category { CategoryName = "Suit"},
            //};
            //categories.ForEach(s => context.Category.AddOrUpdate(s));
            //context.SaveChanges();
        }
    }
}
