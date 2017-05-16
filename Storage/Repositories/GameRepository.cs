﻿// (C) IMT - Information Management Technology AG, CH-9470 Buchs, www.imt.ch.
// SW Guideline: Technote Coding Guidelines Ver. 1.4

using System.Collections.Generic;
using System.Linq;
using System;
using Ludothek.Storage.Models;

namespace Ludothek.Storage {
    public class GameRepository : RepositoryBase {


        public List<Spiel> GetAllGames()
        {
            using (DbContext = new LudothekDbEntities())
            {
                return DbContext.Spiel.ToList();
            }
        }

        public Spiel GetGame(Guid id)
        {
            using (DbContext = new LudothekDbEntities())
            {
                return DbContext.Spiel.FirstOrDefault(s => s.SpielKeyGUID == id);
            }  
        }


        public bool AddGame(Spiel spiel)
        {
            using(DbContext = new LudothekDbEntities())
            {
                DbContext.Spiel.Add(spiel);
                return DbContext.SaveChanges() > 0;
            }
        }
    }
}