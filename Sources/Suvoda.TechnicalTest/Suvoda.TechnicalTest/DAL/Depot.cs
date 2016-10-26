//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Suvoda.TechnicalTest.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Depot
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Depot()
        {
            this.DepotDestinations = new HashSet<DepotDestination>();
            this.DrugUnits = new HashSet<DrugUnit>();
        }
    
        public int DepotId { get; set; }
        public string DepotName { get; set; }
        public int DepotLocation { get; set; }
    
        public virtual Country Country { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DepotDestination> DepotDestinations { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DrugUnit> DrugUnits { get; set; }
    }
}
