﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UchP11
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class baseEntities : DbContext
    {
        private static baseEntities _context;
        public baseEntities()
            : base("name=baseEntities")
        {
        }
        public  static baseEntities GetContext()
        {
            if(_context==null)
            {
                _context = new baseEntities();
            }
            return _context;
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Istoriya_pokupok> Istoriya_pokupok { get; set; }
        public virtual DbSet<Proizvoditel> Proizvoditel { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Tovar> Tovar { get; set; }
    }
}
