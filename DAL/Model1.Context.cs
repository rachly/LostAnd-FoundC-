﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class lostFoundDBEntities : DbContext
    {
        public lostFoundDBEntities()
            : base("name=lostFoundDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<category> category { get; set; }
        public virtual DbSet<color> color { get; set; }
        public virtual DbSet<Image> Image { get; set; }
        public virtual DbSet<item> item { get; set; }
        public virtual DbSet<users> users { get; set; }
    }
}
