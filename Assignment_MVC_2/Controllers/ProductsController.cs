using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Assignment_MVC_2.Data;
using Assignment_MVC_2.Models;

namespace Assignment_MVC_2.Controllers
{
    public class ProductsController : Controller
    {
        private ShopContext db = new ShopContext();

        // GET: Products
        public ActionResult Index()
        {
            var  product = db.Product.Include(p => p.Category);
            ViewBag.ListCategory = db.Category.ToList();
            return View(product.ToList());
        }

        public ActionResult IndexAjax()
        {
            var product = db.Product.AsQueryable();
            if (Request.QueryString["searchString"] != null)
            {
                string searchString = this.Request.QueryString["searchString"];
                if (!String.IsNullOrEmpty(searchString)) // tìm theo categoryName
                {
                    product = product.Where(s => s.ProductName.Contains(searchString));
                }
                else
                {
                    product = db.Product.Include(p => p.Category);
                }
            }
            if (Request.QueryString["categoryId"] != null)
            {
                int categoryId = int.Parse(this.Request.QueryString["categoryId"]);
                if (categoryId != -1) // tìm theo categoryName
                {
                    product = product.Where(s => s.CategoryId == categoryId);
                }
                else
                {
                    product = db.Product.Include(p => p.Category);
                }
            }
            
            //if (String.IsNullOrEmpty(searchString) && categoryId != -1) // tìm theo categoryName
            //{
            //    product = product.Where(s => s.CategoryId == categoryId);
            //}
            //if (!String.IsNullOrEmpty(searchString) && categoryId == -1) // tìm theo searchString
            //{
            //    product = product.Where(s => s.ProductName.Contains(searchString));
            //}
            //if (!String.IsNullOrEmpty(searchString) && categoryId != -1) // tìm theo searchString và categoryName
            //{
            //    product = product.Where(s => s.ProductName.Contains(searchString) && s.CategoryId == categoryId);
            //}
            //if (String.IsNullOrEmpty(searchString) && categoryId == -1) // categoryName và searchString rỗng
            //{
            //    product = db.Product.Include(p => p.Category);
            //}
            return PartialView("IndexAjax",product.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Category, "Id", "CategoryName");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ProductName,CategoryId,Price")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Product.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Category, "Id", "CategoryName", product.CategoryId);
            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Category, "Id", "CategoryName", product.CategoryId);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ProductName,CategoryId,Price")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Category, "Id", "CategoryName", product.CategoryId);
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Product.Find(id);
            db.Product.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
