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
    
    public partial class TBLPROJELER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBLPROJELER()
        {
            this.TBLUYE_PROJE = new HashSet<TBLUYE_PROJE>();
        }
    
        public int PROJE_REFNO { get; set; }
        public string PROJE_ADI { get; set; }
        public System.DateTime BASLAMA_TARIHI { get; set; }
        public Nullable<System.DateTime> BITIS_TARIHI { get; set; }
        public string KONUMU { get; set; }
        public int SEHIR_REFNO { get; set; }
        public int ILCE_REFNO { get; set; }
        public bool TAMAMLANMA_DURUMU { get; set; }
        public string ACIKLAMA { get; set; }
        public string MEDYA { get; set; }
    
        public virtual TBLILCELER TBLILCELER { get; set; }
        public virtual TBLSEHIRLER TBLSEHIRLER { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBLUYE_PROJE> TBLUYE_PROJE { get; set; }
        public virtual TBLPROJELER TBLPROJELER1 { get; set; }
        public virtual TBLPROJELER TBLPROJELER2 { get; set; }
    }
}