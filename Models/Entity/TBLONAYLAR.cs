//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ExpenceManager.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBLONAYLAR
    {
        public int ONAYID { get; set; }
        public Nullable<int> CALISAN { get; set; }
        public Nullable<decimal> FIYAT { get; set; }
        public string KATEGORI { get; set; }
    
        public virtual TBLCALISANLAR TBLCALISANLAR { get; set; }
    }
}