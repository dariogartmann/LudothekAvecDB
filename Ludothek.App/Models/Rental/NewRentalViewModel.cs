using Ludothek.Storage.Models;
using System;

namespace Ludothek.App.Models.Rental
{
    public class NewRentalViewModel
    {
        public Spiel Game { get; set; }
        public Guid CustomerId { get; set; }

    }
}