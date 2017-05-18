using Ludothek.Storage.Repositories;
using Ludothek.Storage.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using Ludothek.WebApp.Models.Game;

namespace Ludothek.WebApp.Controllers
{
    public class GameController : Controller
    {

        private GameRepository m_gameRepository;

        public GameController() {
            m_gameRepository = new GameRepository();
        }

        // GET: Game
        public ActionResult Index()
        {
            List<Spiel> games = m_gameRepository.GetAllGames();
            return View(new GameListViewModel(games));
        }
    }
}