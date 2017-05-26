using System;
using System.Collections.Generic;
using System.Linq;
using Ludothek.Storage.Models;

namespace Ludothek.Storage.Repositories
{
    public class FederationRepository : RepositoryBase<Verband>
    {
        /// <summary>
        /// get all federations
        /// </summary>
        /// <returns>A list of available federations</returns>
        public List<Verband> GetAllFederations()
        {
            using (DbContext = new LudothekEntities())
            {
                return Read(DbContext).ToList();
            }
        }

        /// <summary>
        /// get a specific federation by its id
        /// </summary>
        /// <param name="id">id to search for</param>
        /// <returns>a federation if one with id exists, otherwise null</returns>
        public Verband GetFederation(Guid id)
        {
            using (DbContext = new LudothekEntities())
            {
                return Read(DbContext, f => f.VerbandKeyGUID == id).FirstOrDefault();
            }
        }

        /// <summary>
        /// save a new federation in the database
        /// </summary>
        /// <param name="federation">federation to write to db</param>
        /// <returns>true if successful, otherwise false</returns>
        public bool Create(Verband federation)
        {
            using (DbContext = new LudothekEntities())
            {
                int affectedRows = Create(DbContext, federation);
                return affectedRows > 0;
            }
        }

        /// <summary>
        /// delete a federation
        /// </summary>
        /// <param name="id">id of federation to delete</param>
        /// <returns>true if successful, otherwise false</returns>
        public bool Delete(Guid id)
        {
            var successful = false;
            Verband federation = GetFederation(id);
            using (DbContext = new LudothekEntities())
            {
                if (federation != null)
                {
                    successful = Delete(DbContext, federation) > 0;
                }
            }
            return successful;
        }

        public bool Update(Guid id, Verband federation)
        {
            var successful = false;
            Verband federationToUpdate = GetFederation(id);
            using (DbContext = new LudothekEntities())
            {
                if (federationToUpdate != null)
                {
                    successful = Update(DbContext, id, federationToUpdate) > 0;
                }
            }
            return successful;
        }
    }
}
