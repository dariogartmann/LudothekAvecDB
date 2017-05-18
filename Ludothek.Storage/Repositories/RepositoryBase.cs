using Ludothek.Storage.Models;
using System;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;

namespace Ludothek.Storage.Repositories
{
    /// <summary>
    /// handles basic CRUD functionality using T
    /// </summary>
    public abstract class RepositoryBase<TEntity> where TEntity : class
    {
        #region Properties

        public LudothekEntities DbContext;
        
        #endregion
        
        #region CRUD

        /// <summary>
        /// create a new entity
        /// </summary>
        /// <param name="entity">entity to create</param>
        /// <returns>number of affected rows</returns>
        public int Create(LudothekEntities context, TEntity entity)
        {
            context.Set<TEntity>().Add(entity);

            var numberOfAffectedRows = context.SaveChanges();

            return numberOfAffectedRows;
        }

        /// <summary>
        /// Get all entities 
        /// </summary>
        /// <param name="expression">expression for find a specified entity. Default value null returns all entities</param>
        /// <returns>a list of entities</returns>
        public IQueryable<TEntity> Read(LudothekEntities context, Expression<Func<TEntity, bool>> expression = null)
        {
            var query = expression != null ? context.Set<TEntity>().Where(expression) : context.Set<TEntity>();
            return query;
        }

        /// <summary>
        /// update an existing entity
        /// </summary>
        /// <param name="id">entity id to update</param>
        /// <param name="newEntity">entity with new values</param>
        /// <returns>number of affected rows.</returns>
        public int Update(LudothekEntities context, Guid id, TEntity newEntity)
        {
            context.Set<TEntity>().AddOrUpdate(newEntity);

            var numberOfAffectedRows = context.SaveChanges();

            return numberOfAffectedRows;
        }

        /// <summary>
        /// delete article and his articlecultures by id
        /// </summary>
        /// <returns>number of affected entries.</returns>
        public int Delete(LudothekEntities context, TEntity entity)
        {
            context.Set<TEntity>().Remove(entity);

            return context.SaveChanges();
        }

        #endregion
    }
}