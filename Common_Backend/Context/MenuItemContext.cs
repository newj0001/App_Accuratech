using Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common_Backend
{
    public class MenuItemContext : DbContext
    {
        public MenuItemContext(): base("DefaultConnection") { }

        public DbSet<MenuItemEntity> Menus { get; set; }
    }
}
