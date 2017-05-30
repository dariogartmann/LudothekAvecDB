using Ludothek.App.Models.Rental;
using Ludothek.Storage.Models;
using Ludothek.Storage.Repositories;
using System;
using System.Web.Mvc;

namespace Ludothek.App.Controllers
{
    public class RentalController : Controller
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
            // todo find id of user and pass to repo method
            // List<Ausleihe> rentals = m_rentalRepository.GetRentalsForCustomer(null);
            // return View("Index", rentals);
            return View();
        }

        // GET: Rental/New?gameId=..
        public ActionResult New(Guid? gameId)
        {
            if (!gameId.HasValue)
            {
                return RedirectToAction("Index", "Home");
            }
            Spiel game = m_gameRepository.GetGame(gameId.Value);

            var user = HttpContext.User.Identity;

            NewRentalViewModel viewModel = new NewRentalViewModel();
            viewModel.Game = game;
            viewModel.CustomerId = Guid.Empty; // todo fix

            return View("New", viewModel);
        }

        // POST: Rental/New
        [HttpPost]
        public ActionResult New()
        {
            return View("New");
        }
    }
}