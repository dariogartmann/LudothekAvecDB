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
    
    public partial class Kunde
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Kunde()
        {
            this.Ausleihe = new HashSet<Ausleihe>();
        }
    
        public System.Guid KundenKeyGUID { get; set; }
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public System.DateTime Geburtsdatum { get; set; }
        public string Strasse { get; set; }
        public string Ort { get; set; }
        public int PLZ { get; set; }
        public bool IstFilialvorstandsmitglied { get; set; }
        public System.Guid FK_Filiale { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ausleihe> Ausleihe { get; set; }
        public virtual Filiale Filiale { get; set; }
    }
}
