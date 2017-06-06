using Ludothek.App.Models;
using Ludothek.Storage.Models;
using Ludothek.Storage.Repositories;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Ludothek.App.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Ludothek.App.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Ludothek.App.Models.ApplicationDbContext context)
        {
            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Admin" };

                manager.Create(role);
            }

            if (!context.Users.Any(u => u.UserName == "admin@ludothek.ch"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "admin@ludothek.ch", Email = "admin@ludothek.ch", EmailConfirmed = true };

                manager.Create(user, "InitialPW$5");
                manager.AddToRole(user.Id, "Admin");

                CustomerRepository customerRepo = new CustomerRepository();
                Kunde customer = new Kunde
                {
                    KundenKeyGUID = new Guid(user.Id),
                    Geburtsdatum = DateTime.Now,
                    Vorname = "Administrator",
                    Nachname = "Administrator",
                    Strasse = "Default",
                    Ort = "Default",
                    PLZ = 9000,
                    IstFilialvorstandsmitglied = true
                };
                customerRepo.Create(customer);

            }
        }
    }
}
