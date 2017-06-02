using System;
using System.Data.Entity;
using System.Linq;
using Ludothek.Storage.Models;

namespace Ludothek.Storage.Repositories
{
    public class CustomerRepository : RepositoryBase<Kunde>
    {

        /// <summary>
        /// get a specific customer by id
        /// </summary>
        /// <param name="id">id to search for</param>
        /// <returns>a customer if one with id exists, otherwise null</returns>
        public Kunde GetCustomer(Guid id)
        {
            using (DbContext = new LudothekEntities())
            {
                return Read(DbContext, c => c.KundenKeyGUID == id)
                    .Include(c => c.Ausleihe)
                    .FirstOrDefault();
            }
        }

        /// <summary>
        /// save a new customer in the database
        /// </summary>
        /// <param name="customer">customer to write to db</param>
        /// <returns>true if successful, otherwise false</returns>
        public bool Create(Kunde customer) {
            using (DbContext = new LudothekEntities()) {
                customer.Filiale = DbContext.Filiale.FirstOrDefault(); // todo, select branch somehow

                int affectedRows = Create(DbContext, customer);
                return affectedRows > 0;
            }
        }

        /// <summary>
        /// delete a customer
        /// </summary>
        /// <param name="id">id of customer to delete</param>
        /// <returns>true if successful, otherwise false</returns>
        public bool Delete(Guid id) {
            throw new NotImplementedException();
        }

        /// <summary>
        /// update a customer
        /// </summary>
        /// <param name="customer">locally updated customer</param>
        /// <returns>true if successful, otherwise false</returns>
        public bool Update(Kunde customer) {
            var successful = false;
            using (DbContext = new LudothekEntities()) {
                if (customer != null) {
                    successful = Update(DbContext, customer.KundenKeyGUID, customer) > 0;
                }
            }
            return successful;
        }
    }
}
