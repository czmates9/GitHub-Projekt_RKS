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
    
    public partial class SESTAVA
    {
        public int ID { get; set; }
        public int ID_STROJ { get; set; }
        public int ID_SESTAVA_DEF { get; set; }
    
        public virtual SESTAVA_DEFINICE SESTAVA_DEFINICE { get; set; }
        public virtual STROJ STROJ { get; set; }
    }
}
