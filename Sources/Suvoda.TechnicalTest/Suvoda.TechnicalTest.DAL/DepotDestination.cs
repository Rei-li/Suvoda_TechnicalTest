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
    
    public partial class DepotDestination
    {
        public int DepotId { get; set; }
        public int CountryId { get; set; }
        public int Id { get; set; }
    
        public virtual Country Country { get; set; }
        public virtual Depot Depot { get; set; }
    }
}