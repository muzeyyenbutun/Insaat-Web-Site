//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace INSAATTaksitTakip.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBLMESAJLAR
    {
        public int MESAJ_REFNO { get; set; }
        public string AD_SOYAD { get; set; }
        public string TELEFON { get; set; }
        public string MAIL { get; set; }
        public string BASLIK { get; set; }
        public string ICERIK { get; set; }
        public Nullable<int> UYE_REFNO { get; set; }
    
        public virtual TBLUYELER TBLUYELER { get; set; }
    }
}