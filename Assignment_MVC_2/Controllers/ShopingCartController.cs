using Assignment_MVC_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment_MVC_2.Controllers
{
    public class ShopingCartController : Controller
    {
        // GET: ShopingCart
        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult Create()
        {
            ShopingCart shopingCart = new ShopingCart();
            shopingCart.listCartItem = Session["giohang"] as List<CartItem>;
            return View(shopingCart);
        }

        [HttpGet]
        public ActionResult Checkout()
        {
            string ShipName = Request.QueryString["ShipName"];
            string ShipAddress = Request.QueryString["ShipAddress"];
            string ShipPhone = Request.QueryString["ShipPhone"];

            ShopingCart shopingCart = new ShopingCart();
            shopingCart.ShipName = ShipName;
            shopingCart.ShipAddress = ShipAddress;
            shopingCart.ShipPhone = ShipPhone;
            shopingCart.listCartItem = Session["giohang"] as List<CartItem>;
            Session.Remove("giohang");
            return View(shopingCart);
        }

    }
}