using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Ludothek.Storage.Models;

namespace Ludothek.Storage.Repositories
{
    public class RentalRepository : RepositoryBase<Ausleihe>
    {

        #region Get Methods

        /// <summary>
        /// get all available rentals
        /// </summary>
        /// <returns>all rentals</returns>
        public List<Ausleihe> GetAllRentals()
        {
            using (DbContext = new LudothekEntities())
            {
                return DbContext.Ausleihe
                    .Include(r => r.Kunde)
                    .Include(r => r.Spiel)
                    .ToList();
            }
        }

        /// <summary>
        /// get a specific rental by its id
        /// </summary>
        /// <param name="id">id of rental</param>
        /// <returns>a rental object</returns>
        public Ausleihe GetRentalById(Guid id)
        {
            using (DbContext = new LudothekEntities())
            {
                return DbContext.Ausleihe.Where(a => a.AusleiheKeyGUID == id)
                    .Include(r => r.Kunde)
                    .Include(r => r.Spiel)
                    .FirstOrDefault();
            }
        }

        /// <summary>
        /// get rentals for a specific user
        /// </summary>
        /// <param name="customerId">id of the user</param>
        /// <param name="onlyActive">only rentals that are active (have not ended) should be returned</param>
        /// <returns>list of rentals belonging to a customer</returns>
        public List<Ausleihe> GetRentalsForCustomer(Guid customerId, bool onlyActive = false)
        {
            using (DbContext = new LudothekEntities())
            {
                if (onlyActive)
                {
                    return Read(DbContext, s => s.Kunde.KundenKeyGUID == customerId && s.Enddatum > DateTime.Now)
                        .Include(r => r.Spiel)
                        .ToList();
                }
                return Read(DbContext, s => s.Kunde.KundenKeyGUID == customerId)
                    .Include(r => r.Spiel)
                    .ToList();
            }
        }


        #endregion

        #region Manage Rentals

        /// <summary>
        /// creates a new rental obect
        /// </summary>
        /// <param name="customerId">id of customer who rents</param>
        /// <param name="gameId">id of the game to rent</param>
        /// <returns>true if successful, otherwise false</returns>
        public bool AddRental(Guid customerId, Guid gameId)
        {
            using (DbContext = new LudothekEntities())
            {
                using (var transaction = DbContext.Database.BeginTransaction())
                {

                    try
                    {
                        Spiel game = DbContext.Spiel.FirstOrDefault(g => g.SpielKeyGUID == gameId);
                        Kunde customer = DbContext.Kunde.FirstOrDefault(c => c.KundenKeyGUID == customerId);

                        if (game == null || !game.IsAvailable)
                        {
                            transaction.Dispose();
                            return false;
                        }

                        Ausleihe rental = new Ausleihe
                        {
                            AusleiheKeyGUID = Guid.NewGuid(),
                            Startdatum = DateTime.Now,
                            Enddatum = DateTime.Now.AddDays(7),
                            Kunde = customer,
                            Spiel = game
                        };

                        game.IsAvailable = false;
                        DbContext.Entry(game).State = EntityState.Modified;
                        DbContext.Ausleihe.Add(rental);

                        DbContext.SaveChanges();
                        transaction.Commit();
                        return true;
                    }
                    catch (Exception e)
                    {
                        transaction.Rollback();
                        return false;
                    }
                }
            }
        }

        /// <summary>
        /// cancels a rental ( > delete from db)
        /// </summary>
        /// <param name="rentalId">id of rental to cancel</param>
        /// <returns>true if successful, otherwise false</returns>
        public bool CancelRental(Guid rentalId)
        {
            using (DbContext = new LudothekEntities())
            {
                using (var transaction = DbContext.Database.BeginTransaction())
                {
                    try
                    {
                        Ausleihe rental = DbContext.Ausleihe.FirstOrDefault(r => r.AusleiheKeyGUID == rentalId);

                        if (rental != null)
                        {
                            rental.Spiel.IsAvailable = true;
                            DbContext.Entry(rental.Spiel).State = EntityState.Modified;

                            DbContext.Ausleihe.Remove(rental);
                            DbContext.SaveChanges();

                            transaction.Commit();
                            return true;
                        }
                    }
                    catch (Exception e)
                    {
                        transaction.Rollback();
                        return false;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// prolong a rental about a week
        /// </summary>
        /// <param name="rentalId">rental to prolong</param>
        /// <returns>true if successful</returns>
        public bool ProlongRental(Guid rentalId)
        {
            using (DbContext = new LudothekEntities())
            {
                using (var transaction = DbContext.Database.BeginTransaction())
                {
                    try
                    {
                        Ausleihe rental = DbContext.Ausleihe.FirstOrDefault(r => r.AusleiheKeyGUID == rentalId);

                        if (rental != null)
                        {
                            rental.Enddatum = rental.Enddatum.AddDays(7);
                            DbContext.Entry(rental.Spiel).State = EntityState.Modified;

                            DbContext.SaveChanges();

                            transaction.Commit();
                            return true;
                        }
                    }
                    catch (Exception e)
                    {
                        transaction.Rollback();
                        return false;
                    }
                }
            }
            return false;
        }

        #endregion

    }
}