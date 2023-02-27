using EFCodeFirst.EF;
using EFCodeFirst.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFCodeFirst.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {
            PMSDb db = new PMSDb();
            return View(db.Products.ToList());
        }
        public ActionResult AddCart(int id) {
            PMSDb db = new PMSDb();
            //var pr = db.Products.FirstOrDefault(p => p.Id == id);
            //var pr = (from p in db.Products where p.Id == id select p).SingleOrDefault();
            var pr = db.Products.Find(id);

            List<Product> cart = null;
            if (Session["cart"] == null) {
                cart = new List<Product>();  
            }
            else
            {
                cart = (List<Product>)Session["cart"];
            }
            if (!Exist(id))
            {
                cart.Add(new Product()
                {
                    Id = pr.Id,
                    Qty = 1,
                    Price = pr.Price,
                    Name = pr.Name,
                });
                Session["cart"] = cart;

                TempData["Msg"] = "Successfully Added";
                return RedirectToAction("Index");

            }
            else {
                TempData["Msg"] = "Already Added";
                return RedirectToAction("Index");
            }
            
           

        }
        public ActionResult Place() {
            var products = (List<Product>)Session["cart"];
            Order o = new Order();
            o.OrderDate = DateTime.Now;
            PMSDb db = new PMSDb();
            db.Orders.Add(o);
            db.SaveChanges();
            foreach(var p in products)
            {
                OrderDetails od = new OrderDetails();
                od.OId = o.Id;
                od.PId = p.Id;
                od.Price =(int) p.Price;
                od.Qty = p.Qty;
                db.OrderDetails.Add(od);
                db.Products.Find(p.Id).Qty -= p.Qty;
            }
            db.SaveChanges();
            TempData["Msg"] = "Order Placed Successfully";
            return RedirectToAction("Index");
        }
        public bool Exist(int id)
        {
            if (Session["cart"] != null) {
                var products = (List<Product>)Session["cart"];
                var p = (from pro in products where pro.Id == id select pro).SingleOrDefault();
                if (p != null) return true;
            }
            return false;
        }

        public ActionResult ShowCart() {
            var products = (List<Product>)Session["cart"];
            return View(products);
        }
    }
}