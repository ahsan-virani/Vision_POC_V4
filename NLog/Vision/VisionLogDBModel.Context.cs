﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NLog.Vision
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class VisionLogDBModel : DbContext
    {
        public VisionLogDBModel()
            : base("name=VisionLogDBModel")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ACTION_TYPE> ACTION_TYPE { get; set; }
        public virtual DbSet<GLOBAL_AUDIT> GLOBAL_AUDIT { get; set; }
        public virtual DbSet<LOG_TYPE> LOG_TYPE { get; set; }
        public virtual DbSet<GLOBAL_AUDIT_DATA> GLOBAL_AUDIT_DATA { get; set; }
    }
}
