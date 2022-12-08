//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RKC_IS.DataAccess.Model.AutoMapping
{
    using System;
    using System.Collections.Generic;
    
    public partial class VZORKOVANI
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VZORKOVANI()
        {
            this.MATERIAL = new HashSet<MATERIAL>();
            this.USER_VZORKOVANI = new HashSet<USER_VZORKOVANI>();
        }
    
        public int ID { get; set; }
        public int ID_FORMA { get; set; }
        public int ID_STROJ { get; set; }
        public Nullable<System.DateTime> DatumZadani { get; set; }
        public Nullable<System.DateTime> DatumOdeslani { get; set; }
        public Nullable<System.DateTime> DatumVzorkovani { get; set; }
        public Nullable<System.DateTime> Deadline { get; set; }
        public string Prijemce { get; set; }
        public string RS { get; set; }
        public string Poznamka { get; set; }
        public string UvolnenoDE { get; set; }
        public int STAV { get; set; }
        public Nullable<int> STAV_NASLEDUJICI { get; set; }
        public int C_USER { get; set; }
        public System.DateTime C_DATE { get; set; }
        public Nullable<int> M_USER { get; set; }
        public Nullable<System.DateTime> M_DATE { get; set; }
    
        public virtual FORMA FORMA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MATERIAL> MATERIAL { get; set; }
        public virtual STROJ STROJ { get; set; }
        public virtual SY_STAV SY_STAV { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<USER_VZORKOVANI> USER_VZORKOVANI { get; set; }
    }
}