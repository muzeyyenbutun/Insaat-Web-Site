﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class INSAATBITIRMEEntities2 : DbContext
    {
        public INSAATBITIRMEEntities2()
            : base("name=INSAATBITIRMEEntities2")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TBLACIKPOZISYONLAR> TBLACIKPOZISYONLAR { get; set; }
        public virtual DbSet<TBLBASIN> TBLBASIN { get; set; }
        public virtual DbSet<TBLGELIR_GIDER> TBLGELIR_GIDER { get; set; }
        public virtual DbSet<TBLGENELBASVURU> TBLGENELBASVURU { get; set; }
        public virtual DbSet<TBLGG_TIPI> TBLGG_TIPI { get; set; }
        public virtual DbSet<TBLILCELER> TBLILCELER { get; set; }
        public virtual DbSet<TBLKULLANICILAR> TBLKULLANICILAR { get; set; }
        public virtual DbSet<TBLKULLANICITIPLERI> TBLKULLANICITIPLERI { get; set; }
        public virtual DbSet<TBLMESAJLAR> TBLMESAJLAR { get; set; }
        public virtual DbSet<TBLPROJELER> TBLPROJELER { get; set; }
        public virtual DbSet<TBLREFERANSLAR> TBLREFERANSLAR { get; set; }
        public virtual DbSet<TBLSAYFA> TBLSAYFA { get; set; }
        public virtual DbSet<TBLSEHIRLER> TBLSEHIRLER { get; set; }
        public virtual DbSet<TBLUYE_HAREKET> TBLUYE_HAREKET { get; set; }
        public virtual DbSet<TBLUYE_PROJE> TBLUYE_PROJE { get; set; }
        public virtual DbSet<TBLUYELER> TBLUYELER { get; set; }
        public virtual DbSet<TBLLOGIN> TBLLOGIN { get; set; }
    }
}
