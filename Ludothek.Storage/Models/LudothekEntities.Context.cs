﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ludothek.Storage.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class LudothekDbEntities : DbContext
    {
        public LudothekDbEntities()
            : base("name=LudothekDbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Ausleihe> Ausleihe { get; set; }
        public virtual DbSet<Bestellung> Bestellung { get; set; }
        public virtual DbSet<Filiale> Filiale { get; set; }
        public virtual DbSet<Kunde> Kunde { get; set; }
        public virtual DbSet<Mitarbeiter> Mitarbeiter { get; set; }
        public virtual DbSet<Spiel> Spiel { get; set; }
        public virtual DbSet<SpielBestellung> SpielBestellung { get; set; }
        public virtual DbSet<Tarifkategorie> Tarifkategorie { get; set; }
        public virtual DbSet<Verband> Verband { get; set; }
        public virtual DbSet<Verlag> Verlag { get; set; }
    }
}