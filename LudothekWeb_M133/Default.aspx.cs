// (C) IMT - Information Management Technology AG, CH-9470 Buchs, www.imt.ch.
// SW Guideline: Technote Coding Guidelines Ver. 1.4

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using LudothekAvecDB.Models;
using LudothekAvecDB.Pages;
using LudothekWeb_M133.Storage;

namespace LudothekAvecDB {
    public partial class _Default : SecurePageBase {
        #region Methodes

        protected void Page_Load(object sender, EventArgs e) {

            var gameId = Request.QueryString["gameId"];

            if (gameId != null) {
                // was?

            } else {
                List<Spiel> games = GameRepository.GetAllGames();
                foreach (Spiel game in games) {
                    gamesList.InnerHtml += RenderGame(game);
                }
            }
        }

        private static string RenderGame(Spiel game) {
            return "<div class=\"col-md-3 game\">" +
                        $"<h3>{game.Name}</h3>" +
                        $"<p>Ort: CHF {game.Ort}</p>" +
                        $"<a class=\"btn btn-primary\" href=\"/Default.aspx?gameId={game.SpielKeyGUID}\">Rent game!</a><hr/>" +
                    "</div>";
        }

        #endregion
    }
}