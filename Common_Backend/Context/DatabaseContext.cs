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
        public DatabaseContext() : base("Server=NTHVISION\\MSSQLSERVER1;Database=MenuDetails;Trusted_Connection=True;") { }

        public DbSet<MenuItemEntity> Menus { get; set; }
    }
}
