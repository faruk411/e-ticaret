using e_ticaret_MVC.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace e_ticaret_MVC.Entity
{
    public class IdentityInitializer: DropCreateDatabaseIfModelChanges<IdentityDataContext>
    {
        protected override void Seed(IdentityDataContext context)
        {
            // Rolleri
            if(!context.Roles.Any(i=>i.Name == "admin"))
            {
                var store = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(store);

                var role = new ApplicationRole() { Name="admin",Description="admin rolü"};
                manager.Create(role);
            }

            
            if (!context.Roles.Any(i => i.Name == "user"))
            {
                var store = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(store);

                var role = new ApplicationRole() { Name = "user", Description = "user rolü" };
                manager.Create(role);
            }
            // User
            if (!context.Users.Any(i => i.Name == "omerfarukcirpan"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);

                var user = new ApplicationUser() { Name="Ömer Faruk",Surname="Çırpan",UserName="omerfarukcirpan",Email="omerfarukcirpan@gmail.com"};
                

                manager.Create(user,"1453326507");
                manager.AddToRole(user.Id,"admin");
                manager.AddToRole(user.Id, "user");

            }
            if (!context.Users.Any(i => i.Name == "farukcirpan"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);

                var user = new ApplicationUser() { Name = "Faruk", Surname = "Çırpan", UserName = "farukcirpan", Email = "farukcirpan@gmail.com" };


                manager.Create(user, "1453326507");
               
                manager.AddToRole(user.Id, "user");

            }

            // User



            base.Seed(context);
        }
    }
}