using Ludothek.Storage.Models;
using System.Collections.Generic;

namespace Ludothek.Storage.Repositories
{
    public class RentalRepository : RepositoryBase {

        public RentalRepository(string storagePath) {
            // bla
        }

        public List<Ausleihe> GetAllRentals()
        {
            using(DbContext )
        }
    
    }
}