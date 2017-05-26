using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Ludothek.Storage.Models;

namespace Ludothek.Storage.Repositories
{
    public class PriceCategoryRepository : RepositoryBase<Tarifkategorie>
    {
        /// <summary>
        /// get all price categories
        /// </summary>
        /// <returns>A list of available price categories</returns>
        public List<Tarifkategorie> GetAllPriceCategories() {
            using (DbContext = new LudothekEntities()) {
                return Read(DbContext).ToList();
            }
        }

        /// <summary>
        /// get a specific category by its id
        /// </summary>
        /// <param name="id">id to search for</param>
        /// <returns>a category if one with id exists, otherwise null</returns>
        public Tarifkategorie GetPriceCategory(Guid id)
        {
            using (DbContext = new LudothekEntities())
            {
                return Read(DbContext, f => f.TarifkategorieKeyGUID == id).Include(c => c.Spiel).FirstOrDefault();
            }
        }

        /// <summary>
        /// save a new category in the database
        /// </summary>
        /// <param name="category">price category to write to db</param>
        /// <returns>true if successful, otherwise false</returns>
        public bool Create(Tarifkategorie category) {
            using (DbContext = new LudothekEntities()) {
                int affectedRows = Create(DbContext, category);
                return affectedRows > 0;
            }
        }

        /// <summary>
        /// delete a category
        /// </summary>
        /// <param name="id">id of branch to category</param>
        /// <returns>true if successful, otherwise false</returns>
        public bool Delete(Guid id) {
            var successful = false;
            Tarifkategorie category = GetPriceCategory(id);
            using (DbContext = new LudothekEntities()) {
                if (category != null) {
                    successful = Delete(DbContext, category) > 0;
                }
            }
            return successful;
        }

        /// <summary>
        /// update a category
        /// </summary>
        /// <param name="filiale">locally updated category</param>
        /// <returns>true if successful, otherwise false</returns>
        public bool Update(Tarifkategorie category) {
            var successful = false;
            using (DbContext = new LudothekEntities()) {
                if (category != null) {
                    successful = Update(DbContext, category.TarifkategorieKeyGUID, category) > 0;
                }
            }
            return successful;
        }
    }
}
