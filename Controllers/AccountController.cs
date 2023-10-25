using e_ticaret_MVC.Entity;
using e_ticaret_MVC.Identity;
using e_ticaret_MVC.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace e_ticaret_MVC.Controllers
{
    public class AccountController : Controller
    {
        private DataContext db = new DataContext();
        private UserManager<ApplicationUser> UserManager;
        private RoleManager<ApplicationRole> RoleManager;
        public AccountController()
        {
            var userStore = new UserStore<ApplicationUser>(new IdentityDataContext());
            UserManager = new UserManager<ApplicationUser>(userStore);
            var roleStore = new RoleStore<ApplicationRole>(new IdentityDataContext());
            RoleManager = new RoleManager<ApplicationRole>(roleStore);
        }
        [Authorize]
        public ActionResult Index()
        {
            var username = User.Identity.Name;
            var orders = db.Orders
                .Where(i=>i.Username == username)
                .Select(i=>new UserOrderModel()
                {
                    Id = i.Id,
                    OrderNumber = i.OrderNumber,
                    Deta=i.Deta,
                    OrderState = i.OrderState,
                    Total=i.Total

                }).OrderByDescending(i=>i.Deta).ToList();    



            return View(orders);
        }
        [Authorize]
        public ActionResult Details(int id)
        {
            var entity = db.Orders.Where(i => i.Id == id)
                .Select(i => new OrderDetailsModel() 
                {
                    OrderId = i.Id,
                    OrderNumber = i.OrderNumber,
                    Total = i.Total,
                    Deta =i.Deta,
                    OrderState=i.OrderState,
                    AdresBasliği=i.AdresBasliği,
                    Adres=i.Adres,
                    Sehir=i.Sehir, 
                    Semt=i.Semt,
                    Mahalle=i.Mahalle,
                    PostaKodu=i.PostaKodu,
                    OrderLines=i.OrderLines.Select(a=>new OrderLineModel()
                    {
                        ProductId = a.ProductId,
                        ProductName=a.Product.Name.Length>50?a.Product.Name.Substring(0,47)+"...":a.Product.Name,
                        Image=a.Product.Image,
                        Quantity=a.Quantity,
                        Price=a.Price
                    }).ToList(),
                }).FirstOrDefault();

            return View(entity);
        }
        // GET: Account
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Register model)
            
        {
            if(ModelState.IsValid)
            {
                //kayıt işlemleri
                ApplicationUser user=new ApplicationUser();
                user.Name = model.Name;
                user.Email = model.Email;
                user.Surname = model.Surname;
                user.UserName = model.Username;

                var result = UserManager.Create(user,model.Password);
                if(result.Succeeded)
                {
                    if (RoleManager.RoleExists("user"))
                    {
                        UserManager.AddToRole(user.Id,"user");
                    }
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    ModelState.AddModelError("RegisterUserError", "Kullanıcı oluşturma hatası.");
                }
            }
            return View();
        }
        //Get
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Models.Login model,string ReturnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = UserManager.Find(model.Username,model.Password);
                if(user != null)
                {
                    // var olan kullanıcıyı sisteme dahil et
                    // ApplicationCookie oluşturup sisteme bırak
                    var autManager =  HttpContext.GetOwinContext().Authentication;
                    var identityclaims = UserManager.CreateIdentity(user, "ApplicationCookie");
                    var autProperties = new AuthenticationProperties();
                    autProperties.IsPersistent = model.RememberMe;
                    autManager.SignIn(autProperties,identityclaims);
                    if(!String.IsNullOrEmpty(ReturnUrl))
                    {
                        return Redirect(ReturnUrl);
                    }
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                ModelState.AddModelError("LoginUserError", "Böyle bir kullanıcı yok");
            }
            return View();
        }
        public ActionResult Logout()
        {
            var autManager = HttpContext.GetOwinContext().Authentication;
            autManager.SignOut();

            return RedirectToAction("Index","Home");
        }
     
    }
}