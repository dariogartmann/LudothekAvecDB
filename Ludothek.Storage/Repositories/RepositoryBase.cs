using Ludothek.Storage.Models;

namespace Ludothek.Storage.Repositories
{
    /// <summary>
    /// base class for repositories
    /// </summary>
    public abstract class RepositoryBase
    {
        public LudothekDbEntities DbContext;
    }
}