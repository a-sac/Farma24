﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Farma24.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Farma24DBEntities : DbContext
    {
        public Farma24DBEntities()
            : base("name=Farma24DBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Encomenda> Encomendas { get; set; }
        public virtual DbSet<Encomenda_has_Produto> Encomenda_has_Produto { get; set; }
        public virtual DbSet<Fatura> Faturas { get; set; }
        public virtual DbSet<Morada> Moradas { get; set; }
        public virtual DbSet<Produto> Produtoes { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Utilizador> Utilizadors { get; set; }
    }
}
