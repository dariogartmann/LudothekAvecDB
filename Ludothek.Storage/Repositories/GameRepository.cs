// (C) IMT - Information Management Technology AG, CH-9470 Buchs, www.imt.ch.
// SW Guideline: Technote Coding Guidelines Ver. 1.4

using Ludothek.Storage.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ludothek.Storage.Repositories {
    public class GameRepository : RepositoryBase<Spiel> {

        /// <summary>
        /// get a list of all games (unfiltered)
        /// </summary>
        /// <returns>return a list of all games</returns>
        public List<Spiel> GetAllGames()
        {
            using (DbContext = new LudothekEntities())
            {
                return Read(DbContext).ToList();
            }
        }

        /// <summary>
        /// get a specific game
        /// </summary>
        /// <param name="id">id of game as guid</param>
        /// <returns>a game</returns>
        public Spiel GetGame(Guid id)
        {
            using (DbContext = new LudothekEntities())
            {
                return DbContext.Spiel.FirstOrDefault(s => s.SpielKeyGUID == id);
            }
        }

        /// <summary>
        /// add a game to database
        /// </summary>
        /// <param name="spiel">game to add</param>
        /// <returns>true if successful</returns>
        public bool Create(Spiel spiel)
        {
            using (DbContext = new LudothekEntities())
            {
                int affectedRows = Create(DbContext, spiel);
                return affectedRows > 0;
            }
        }
    }
}