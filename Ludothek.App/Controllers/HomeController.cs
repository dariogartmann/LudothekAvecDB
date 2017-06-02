using System.Web.Mvc;
using Ludothek.App.Controllers.Base;
using Ludothek.Storage.Repositories;

namespace Ludothek.App.Controllers
{
    public class HomeController : BaseController
    {
        private readonly GameRepository m_gameRepository;

        public HomeController() {
            m_gameRepository = new GameRepository();
        }

        public ActionResult Index()
        {
            var games = m_gameRepository.GetAvailableGames();
            return View("Index", games);
        }
    }
}