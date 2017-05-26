﻿using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Ludothek.App.Models.Game;
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
            return View("Index", new GameListViewModel(games));
        }
    }
}