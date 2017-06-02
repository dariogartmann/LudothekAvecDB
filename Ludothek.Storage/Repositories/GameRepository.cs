// (C) IMT - Information Management Technology AG, CH-9470 Buchs, www.imt.ch.
// SW Guideline: Technote Coding Guidelines Ver. 1.4

using Ludothek.Storage.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
                return Read(DbContext)
                    .Include(g => g.Tarifkategorie)
                    .Include(g => g.Filiale)
                    .ToList();
            }
        }

        /// <summary>
        /// get all games that are not currently rented
        /// </summary>
        /// <returns>a list of available games</returns>
        public List<Spiel> GetAvailableGames()
        {
            using(DbContext = new LudothekEntities())
            {
                return Read(DbContext, g => g.IsAvailable).ToList();
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
                return DbContext.Spiel.Where(s => s.SpielKeyGUID == id)
                    .Include(g => g.Tarifkategorie)
                    .Include(g => g.Filiale)
                    .FirstOrDefault();
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
                spiel.IsAvailable = true;
                int affectedRows = Create(DbContext, spiel);
                return affectedRows > 0;
            }
        }

        /// <summary>
        /// update a game object
        /// </summary>
        /// <param name="game">the game</param>
        /// <returns>true if successful, otherwise false</returns>
        public bool Update(Spiel game) {
            var successful = false;
            using (DbContext = new LudothekEntities())
            {
                if (game != null)
                {
                    successful = Update(DbContext, game.SpielKeyGUID, game) > 0;
                }
            }
            return successful;
        }

        /// <summary>
        /// delete a game
        /// </summary>
        /// <param name="id">id of game to delete</param>
        /// <returns>true if successful, otherwise false</returns>
        public bool Delete(Guid id)
        {
            var successful = false;
            Spiel game = GetGame(id);
            using (DbContext = new LudothekEntities())
            {
                if (game != null)
                {
                    successful = Delete(DbContext, game) > 0;
                }
            }
            return successful;
        }
    }
}