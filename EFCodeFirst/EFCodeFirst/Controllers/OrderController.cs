using EFCodeFirst.Auth;
using EFCodeFirst.EF;
using EFCodeFirst.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFCodeFirst.Controllers
{
    [Logged]
    public class OrderController : Controller
    {
        [AdminAccess]
        public ActionResult AllOrders() {
            PMSDb db = new PMSDb();
            return View(db.Orders.ToList());
        }
        // GET: Order
        //[AllowAnonymous]
        public ActionResult Index()
        {
            //if (Session["user"] != null)
            //{
                PMSDb db = new PMSDb();
                return View(db.Products.Take(10).ToList());
            //}
           //return RedirectToAction("Login","Home");
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
        [AdminAccess]
        public ActionResult OrderDetails(int id) {
            PMSDb db = new PMSDb();
            var order = db.Orders.Find(id);
            return View(order);
        }
        [AdminAccess]
        public ActionResult Process(int id) {
            PMSDb db = new PMSDb();
            var order = db.Orders.Find(id);
            foreach (var od in order.OrderDetails) { 
                var p = db.Products.Find(od.PId);
                p.Qty -= od.Qty;
            }

            order.Status = "Processing";
            db.SaveChanges();
            TempData["Msg"] = "Ordered Placed Succcessfully";

            return RedirectToAction("Index");



        }
        [AdminAccess]
        public ActionResult Cancel(int id) {
            PMSDb db = new PMSDb();
            var order = db.Orders.Find(id);
            order.Status = "Cancelled By Admin";
            db.SaveChanges();
            TempData["Msg"] = "Ordered Cancelled";

            return RedirectToAction("Index");
        }
    }
}