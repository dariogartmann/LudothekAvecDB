using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Ludothek.Storage.Models;

namespace Ludothek.Storage.Repositories
{
    public class BranchRepository : RepositoryBase<Filiale>
    {
        /// <summary>
        /// get all branches
        /// </summary>
        /// <returns>A list of available branches</returns>
        public List<Filiale> GetAllBranches() {
            using (DbContext = new LudothekEntities()) {
                return Read(DbContext).Include(f => f.Verband).ToList();
            }
        }

        /// <summary>
        /// get a specific branch by its id
        /// </summary>
        /// <param name="id">id to search for</param>
        /// <returns>a branch if one with id exists, otherwise null</returns>
        public Filiale GetBranch(Guid id)
        {
            using (DbContext = new LudothekEntities())
            {
                return Read(DbContext, f => f.FilialKeyGUID == id).Include(f => f.Verband).FirstOrDefault();
            }
        }

        /// <summary>
        /// save a new branch in the database
        /// </summary>
        /// <param name="filiale">branch to write to db</param>
        /// <returns>true if successful, otherwise false</returns>
        public bool Create(Filiale filiale) {
            using (DbContext = new LudothekEntities()) {
                int affectedRows = Create(DbContext, filiale);
                return affectedRows > 0;
            }
        }

        /// <summary>
        /// delete a branch
        /// </summary>
        /// <param name="id">id of branch to delete</param>
        /// <returns>true if successful, otherwise false</returns>
        public bool Delete(Guid id) {
            var successful = false;
            using (DbContext = new LudothekEntities())
            {
                Filiale filiale = DbContext.Filiale.FirstOrDefault(b => b.FilialKeyGUID == id);
                if (filiale != null) {
                    successful = Delete(DbContext, filiale) > 0;
                }
            }
            return successful;
        }

        /// <summary>
        /// update a branch
        /// </summary>
        /// <param name="filiale">locally updated branch</param>
        /// <returns>true if successful, otherwise false</returns>
        public bool Update(Filiale filiale) {
            var successful = false;
            using (DbContext = new LudothekEntities()) {
                if (filiale != null) {
                    successful = Update(DbContext, filiale.FilialKeyGUID, filiale) > 0;
                }
            }
            return successful;
        }
    }
}
