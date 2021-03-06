//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class Spiel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Spiel()
        {
            this.Ausleihe = new HashSet<Ausleihe>();
            this.Ausleihe1 = new HashSet<Ausleihe>();
            this.Ausleihe2 = new HashSet<Ausleihe>();
            this.SpielBestellung = new HashSet<SpielBestellung>();
        }
    
        public System.Guid SpielKeyGUID { get; set; }
        public int EANNummer { get; set; }
        public string Name { get; set; }
        public System.Guid FK_Tarifkategorie { get; set; }
        public string Spielkategorie { get; set; }
        public System.Guid FK_Filiale { get; set; }
        public bool IsAvailable { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ausleihe> Ausleihe { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ausleihe> Ausleihe1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ausleihe> Ausleihe2 { get; set; }
        public virtual Filiale Filiale { get; set; }
        public virtual Tarifkategorie Tarifkategorie { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SpielBestellung> SpielBestellung { get; set; }
    }
}
