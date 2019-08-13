using Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

            modelBuilder.Entity<MenuItemEntity>().HasKey(mic => mic.Id);
            modelBuilder.Entity<SubItemEntity>().HasKey(mic => mic.Id);
            modelBuilder.Entity<MenuItemEntity>().HasMany(m => m.SubItems).WithRequired().HasForeignKey(s => s.MenuItemId);
     

        }

        public DbSet<MenuItemEntity> Menus { get; set; }
        public DbSet<SubItemEntity> SubMenus { get; set; }
    }
}
