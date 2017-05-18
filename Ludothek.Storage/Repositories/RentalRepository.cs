using Ludothek.Storage.Models;
using System.Collections.Generic;
using System.Linq;

namespace Ludothek.Storage.Repositories
{
    public class RentalRepository : RepositoryBase {

        public List<Ausleihe> GetAllRentals()
        {
            using (DbContext = new LudothekEntities())
            {
                return DbContext.Ausleihe.ToList();
            }
        }

    }
}