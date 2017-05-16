﻿// (C) IMT - Information Management Technology AG, CH-9470 Buchs, www.imt.ch.
// SW Guideline: Technote Coding Guidelines Ver. 1.4

using System.Web;
using System.Web.UI;
using LudothekAvecDB.Ludothek.Storage;

namespace LudothekAvecDB.Ludothek.App.Pages
{
    public class SecurePageBase : Page {
        protected GameRepository GameRepository { get; }
        protected RentalRepository RentalRepository { get; }

        public SecurePageBase() {
            // redirect user to login if not authenticated
            if (!HttpContext.Current.User.Identity.IsAuthenticated) {
                HttpContext.Current.Response.Redirect("/Account/Login.aspx");
            }

            GameRepository = new GameRepository();
            RentalRepository = new RentalRepository(Server.MapPath("Storage/rentals.json"));
        }
    }
}