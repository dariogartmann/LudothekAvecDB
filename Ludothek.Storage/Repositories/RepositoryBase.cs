using Ludothek.Storage.Models;

namespace Ludothek.Storage.Repositories
{
    /// <summary>
    /// base class for repositories, containing the dbcontext from EF
    /// </summary>
    public abstract class RepositoryBase
    {
        public LudothekEntities DbContext;
    }
}