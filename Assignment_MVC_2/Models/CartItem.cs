using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment_MVC_2.Models
{
    public class CartItem
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; } // Giá mua hiện tại
        public string ProductName { get; set; }
        public double TotalPrice
        {
            get
            {
                return Quantity * UnitPrice;
            }
        }
        
    }
}