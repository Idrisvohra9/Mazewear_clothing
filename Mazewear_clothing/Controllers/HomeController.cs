using Mazewear_clothing.DAL;
using Mazewear_clothing.Models.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mazewear_clothing.Controllers
{
    public class HomeController : Controller
    {
        MazewearEntities ctx = new MazewearEntities(); 
        public ActionResult Index(string search,int? page)
        {
            HomeIndexViewModel model = new HomeIndexViewModel();
            return View(model.CreateModel(search,4, page));
        }

        public ActionResult Checkout()
        {
            return View();
        }
        public ActionResult CheckoutDetails()
        {
            return View();
        }

        public ActionResult AddToCart(int productId)
        {
            List<Item> cart = (List<Item>)Session["cart"];

            if (cart == null)
            {
                cart = new List<Item>();
                Session["cart"] = cart;
            }

            bool isNew = true;

            foreach (var item in cart)
            {
                if (item.Product.ProductId == productId)
                {
                    item.Quantity += 1;
                    isNew = false;
                    break;
                }
            }

            if (isNew)
            {
                var product = ctx.Tbl_Product.Find(productId);
                cart.Add(new Item()
                {
                    Product = product,
                    Quantity = 1
                });
            }

            return RedirectToAction("Index");
        }

        public ActionResult RemoveFromCart(int productId)
        {
            List<Item> cart = (List<Item>)Session["cart"];
            foreach (var item in cart)
            {
                if (item.Product.ProductId == productId)
                {
                    cart.Remove(item);
                    break;
                }
            }
            Session["cart"] = cart;
            return Redirect("Index");
        }
    }
}