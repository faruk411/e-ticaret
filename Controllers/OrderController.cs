using e_ticaret_MVC.Entity;
using e_ticaret_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace e_ticaret_MVC.Controllers
{
    [Authorize(Roles = "admin")]
    public class OrderController : Controller
    {
        DataContext db = new DataContext();
        // GET: Order
        public ActionResult Index()
        {
            var order = db.Orders.Select(i=>new AdminOrderModel()
            {
                Id = i.Id,
                OrderNumber = i.OrderNumber,
                Deta=i.Deta,
                OrderState = i.OrderState,
                Total=i.Total,
                Count=i.OrderLines.Count
               
            }).OrderByDescending(i=>i.Deta).ToList();

            return View(order);
        }
        public ActionResult Details(int id)
        {
            var entity = db.Orders.Where(i => i.Id == id)
                           .Select(i => new OrderDetailsModel()
                           {
                               OrderId = i.Id,
                               UserName=i.Username,
                               OrderNumber = i.OrderNumber,
                               Total = i.Total,
                               Deta = i.Deta,
                               OrderState = i.OrderState,
                               AdresBasliği = i.AdresBasliği,
                               Adres = i.Adres,
                               Sehir = i.Sehir,
                               Semt = i.Semt,
                               Mahalle = i.Mahalle,
                               PostaKodu = i.PostaKodu,
                               OrderLines = i.OrderLines.Select(a => new OrderLineModel()
                               {
                                   ProductId = a.ProductId,
                                   ProductName = a.Product.Name.Length > 50 ? a.Product.Name.Substring(0, 47) + "..." : a.Product.Name,
                                   Image = a.Product.Image,
                                   Quantity = a.Quantity,
                                   Price = a.Price
                               }).ToList(),
                           }).FirstOrDefault();

            return View(entity);
        }
        public ActionResult UpdateOrderState(int OrderId,EnumOrderState OrderState)
        {
            var order = db.Orders.FirstOrDefault(i=>i.Id == OrderId); 
            if (order != null)
            {
                order.OrderState= OrderState;
                db.SaveChanges();
                TempData["message"] = "Bilgileriniz kayıt edildi";

                return RedirectToAction("Details", new {id=OrderId});
            }

            return RedirectToAction("Index");
        }
    }
}