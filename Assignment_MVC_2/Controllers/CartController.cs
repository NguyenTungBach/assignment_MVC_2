using Assignment_MVC_2.Data;
using Assignment_MVC_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment_MVC_2.Controllers
{
    public class CartController : Controller
    {
        private ShopContext db = new ShopContext();
        // GET: Cart
        public ActionResult Index()
        {
            List<CartItem> giohang = Session["giohang"] as List<CartItem>;
            return View(giohang);
        }

        public ActionResult Add(int SanPhamID)
        {
            if (Session["giohang"] == null) // Nếu giỏ hàng chưa được khởi tạo
            {
                Session["giohang"] = new List<CartItem>();  // Khởi tạo Session["giohang"] là 1 List<CartItem>
            }
            List<CartItem> giohang = Session["giohang"] as List<CartItem>;  // Gán qua biến giohang dễ code

            // Kiểm tra xem sản phẩm khách đang chọn đã có trong giỏ hàng chưa
            if (giohang.FirstOrDefault(m => m.ProductId == SanPhamID) == null) // ko co sp nay trong gio hang
            {
                Product product = db.Product.Find(SanPhamID);  // tim sp theo sanPhamID

                CartItem newItem = new CartItem()
                {
                    ProductId = SanPhamID,
                    ProductName = product.ProductName,
                    Quantity = 1,
                    UnitPrice = product.Price,
                };  // Tạo ra 1 CartItem mới

                giohang.Add(newItem);  // Thêm CartItem vào giỏ 
            }
            else
            {
                // Nếu sản phẩm khách chọn đã có trong giỏ hàng thì không thêm vào giỏ nữa mà tăng số lượng lên.
                CartItem cardItem = giohang.FirstOrDefault(m => m.ProductId == SanPhamID);
                cardItem.Quantity++;
            }

            return RedirectToAction("Index","Cart");
        }

        public ActionResult Delete(int SanPhamID)
        {
            List<CartItem> giohang = Session["giohang"] as List<CartItem>;
            CartItem itemXoa = giohang.FirstOrDefault(m => m.ProductId == SanPhamID);
            if (itemXoa != null)
            {
                giohang.Remove(itemXoa);
            }
            return RedirectToAction("Index", "Cart");
        }

        public ActionResult Edit(int SanPhamID, int soluongmoi)
        {
            // tìm carditem muon sua
            List<CartItem> giohang = Session["giohang"] as List<CartItem>;
            CartItem itemSua = giohang.FirstOrDefault(m => m.ProductId == SanPhamID);
            if (itemSua != null)
            {
                itemSua.Quantity = soluongmoi;
            }
            return RedirectToAction("Index", "Cart");
        }
    }
}