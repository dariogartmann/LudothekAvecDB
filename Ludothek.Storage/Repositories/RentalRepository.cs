using Ludothek.Storage.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ludothek.Storage.Repositories
{
    public class RentalRepository : RepositoryBase<Ausleihe> {

        #region Get Methods

        /// <summary>
        /// get all available rentals
        /// </summary>
        /// <returns>all rentals</returns>
        public List<Ausleihe> GetAllRentals()
        {
            using (DbContext = new LudothekEntities())
            {
                return DbContext.Ausleihe.ToList();
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
                return DbContext.Ausleihe.FirstOrDefault(a => a.AusleiheKeyGUID == id);
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
            using(DbContext = new LudothekEntities())
            {
                if (onlyActive)
                {
                    return Read(DbContext, s => s.Kunde.KundenKeyGUID == customerId && s.Enddatum > DateTime.Now).ToList();
                }
                return Read(DbContext, s => s.Kunde.KundenKeyGUID == customerId).ToList();

            }
        }

        #endregion
    }
}