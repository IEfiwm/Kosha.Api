﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace zarkiaclb
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class AuthEntities : DbContext
    {
        public AuthEntities(string c)
            : base(c)
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tblAuthentication> tblAuthentications { get; set; }
        public virtual DbSet<tblSalInsurenceDiskFactory> tblSalInsurenceDiskFactories { get; set; }
    }
}
