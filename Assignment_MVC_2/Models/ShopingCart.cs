using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assignment_MVC_2.Models
{
    public class ShopingCart
    {
        [Required(ErrorMessage = "Vui lòng nhập Tên người nhận")]
        public string ShipName { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập Địa chỉ")]
        public string ShipAddress { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập Số điện thoại")]
        [RegularExpression(@"(84|0[3|5|7|8|9])+([0-9]{8})", ErrorMessage = "Vui lòng nhập đúng dạng số điện thoại")]
        public string ShipPhone { get; set; }
        public List<CartItem> listCartItem { get; set; }

    }
}