using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment_MVC_2.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public virtual ICollection<Product> Products { get; set; } // 1 danh mục chứa nhiều sản phẩm
    }
}