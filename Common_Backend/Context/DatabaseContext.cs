using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common_Backend.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("Server=NTHVISION\\MSSQLSERVER1;Database=HoneyWellAppDB;Trusted_Connection=True;") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MenuItemEntity>().HasKey(mie => mie.Id);
            modelBuilder.Entity<SubItemEntity>().HasKey(sie => sie.Id);
            modelBuilder.Entity<Registration>().HasKey(r => r.Id);
            modelBuilder.Entity<RegistrationValue>().HasKey(rv => rv.Id);

            modelBuilder.Entity<MenuItemEntity>().HasMany(m => m.SubItems).WithRequired().HasForeignKey(s => s.MenuItemId).WillCascadeOnDelete(true);
            modelBuilder.Entity<Registration>().HasMany(r => r.RegistrationValues).WithRequired().HasForeignKey(rv => rv.RegistrationId).WillCascadeOnDelete(true);
            modelBuilder.Entity<MenuItemEntity>().HasMany(m => m.Registrations).WithRequired().HasForeignKey(r => r.MenuItemId).WillCascadeOnDelete(true);
            modelBuilder.Entity<RegistrationValue>().HasRequired(rv => rv.SubItemEntity).WithMany().HasForeignKey(rv => rv.SubItemId).WillCascadeOnDelete(false);

        }

        public DbSet<MenuItemEntity> Menus { get; set; }
        public DbSet<SubItemEntity> SubMenus { get; set; }
        public DbSet<Registration> Registrations { get; set; }
        public DbSet<RegistrationValue> RegistrationValues { get; set; }
    }
}
