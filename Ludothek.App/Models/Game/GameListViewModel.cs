using Ludothek.Storage.Models;
using System.Collections.Generic;

namespace Ludothek.App.Models.Game
{
    public class GameListViewModel
    {

        public GameListViewModel(List<Spiel> games)
        {
            Games = games;
        }

        public List<Spiel> Games;
    }
}