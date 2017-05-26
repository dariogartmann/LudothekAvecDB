using System.Collections.Generic;
using System.Web.Mvc;
using Ludothek.Storage.Models;
using Ludothek.Storage.Repositories;

namespace Ludothek.App.Controllers
{
    public class HomeController : Controller
    {
        private GameRepository m_gameRepository;

        public HomeController() {
            m_gameRepository = new GameRepository();
        }

        public ActionResult Index()
        {
            List<Spiel> games = m_gameRepository.GetAllGames();
            return View("Index", games);
        }
    }
}