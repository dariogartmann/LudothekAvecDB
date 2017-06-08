using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Ludothek.App.Controllers.Base;
using Ludothek.Storage.Models;
using Ludothek.Storage.Repositories;

namespace Ludothek.App.Controllers
{
    public class RentalController : BaseController
    {
        private RentalRepository m_rentalRepository;
        private GameRepository m_gameRepository;

        public RentalController()
        {
            m_rentalRepository = new RentalRepository();
            m_gameRepository = new GameRepository();
        }

        // GET: Rental
        public ActionResult Index()
        {
            List<Ausleihe> rentals = m_rentalRepository.GetRentalsForCustomer(GetCurrentUserId());
            return View("Index", rentals);
        }

        // GET: Rental/New?gameId=..
        public ActionResult New(Guid? gameId)
        {
            if (System.Web.HttpContext.Current.User != null && System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
            {
                if (!gameId.HasValue)
                {
                    return new HttpStatusCodeResult(400);
                }
                Spiel game = m_gameRepository.GetGame(gameId.Value);

                if (game != null)
                {
                    m_rentalRepository.AddRental(GetCurrentUserId(), game.SpielKeyGUID);

                    return RedirectToAction("Index", "Rental");
                }
            }
            return View("ErrorLogin");
        }

        // GET: Rental/Cancel?rentalId=rentalId
        public ActionResult Cancel(Guid? rentalId)
        {
            if (!rentalId.HasValue)
            {
                return new HttpStatusCodeResult(400);
            }

            Ausleihe rental = m_rentalRepository.GetRentalById(rentalId.Value);

            if (rental != null)
            {
                // check if user is valid
                if (rental.Kunde.KundenKeyGUID == GetCurrentUserId())
                {
                    m_rentalRepository.CancelRental(rental.AusleiheKeyGUID);
                    return RedirectToAction("Index", "Rental");
                }
                return new HttpUnauthorizedResult();
            }

            return new HttpStatusCodeResult(400);

        }

        // GET: Rental/Prolong?rentalId=rentalId
        public ActionResult Prolong(Guid? rentalId)
        {
            if (!rentalId.HasValue)
            {
                return new HttpStatusCodeResult(400);
            }

            Ausleihe rental = m_rentalRepository.GetRentalById(rentalId.Value);

            if (rental != null)
            {
                //make sure that you can't prolong more than 3 times for a week (in total a month)
                if ((rental.Enddatum - rental.Startdatum).TotalDays < 28)
                {
                    // check if user is valid
                    if (rental.Kunde.KundenKeyGUID == GetCurrentUserId())
                    {
                        var success = m_rentalRepository.ProlongRental(rental.AusleiheKeyGUID);
                        if (success)
                        {
                            return RedirectToAction("Index", "Rental");
                        }
                        else
                        {
                            return View("Error");
                        }
                    }
                }
            }
            return View("ErrorProlong");
        }
    }
}