using e_ticaret_MVC.Entity;
using e_ticaret_MVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace e_ticaret_MVC.Controllers
{
   
    public class CartController : Controller
    {
        private DataContext db = new DataContext();
        // GET: Cart
        public ActionResult Index()
        {
            return View(GetCart());
        }
        public ActionResult AddToCart(int Id)
        {
            var product=db.Products.FirstOrDefault(i=>i.Id==Id);
            if(product!=null)
            {
                GetCart().AddProduct(product, 1);
            }
            return Redirect("Index");
        }
        public ActionResult RemoveFromCart(int Id)
        {
            var product = db.Products.FirstOrDefault(i => i.Id == Id);
            if (product != null)
            {
                GetCart().DeleteProduct(product);
            }
            return Redirect("Index");
        }
        public Cart GetCart()
        {
            var cart = (Cart)Session["Cart"];
            if(cart == null)
            {
                cart = new Cart();
                Session["Cart"]= cart;
            }
            return cart;
        }   
        public PartialViewResult Summary()
        {
            return PartialView(GetCart());

        }
        [Authorize]
        public ActionResult Checkout()
        {
            return View(new ShippingDetails());
        }
        [HttpPost]
        public ActionResult Checkout(ShippingDetails entity)
        {
            var cart = GetCart();
            if (cart.CartLines.Count == 0)
            {
                ModelState.AddModelError("UrunYokError", "Sepetinizde ürün bulunamadı");
            }
            if(ModelState.IsValid)
            {
                // siparişi veri tabanına kaydet
                SaveOrder(cart, entity);
                // cartı sıfırla
                cart.Clear();
                return View("Completed");
            }
            else
            {
                return View(entity);
            }
            
        }

        private void SaveOrder(Cart cart, ShippingDetails entity)
        {
            var order=new Order();

            order.OrderNumber ="A"+ (new Random()).Next(11111,99999).ToString();
            order.Total = cart.Total();
            order.Deta=DateTime.Now;
            order.OrderState = EnumOrderState.Bekleniliyor;
            order.Username=User.Identity.Name;

            
            order.AdresBasliği = entity.AdresBasliği;
            order.Adres=entity.Adres;
            order.Sehir = entity.Sehir;
            order.Semt=entity.Semt;
            order.Mahalle=entity.Mahalle;
            order.PostaKodu=entity.PostaKodu;

            order.OrderLines = new List<OrderLine>();
            foreach(var pr in cart.CartLines)
            {
                var orderline = new OrderLine();
                orderline.Quantity = pr.Quantity;
                orderline.Price = pr.Product.Price*pr.Quantity;
                orderline.ProductId = pr.Product.Id;

                order.OrderLines.Add(orderline);
            }
            db.Orders.Add(order);
            db.SaveChanges();
        }
    }
}