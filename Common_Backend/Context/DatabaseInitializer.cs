using Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common_Backend.Context
{
    public class DatabaseInitializer : DropCreateDatabaseIfModelChanges<MenuItemContext>
    {
        protected override void Seed(MenuItemContext context)
        {
            base.Seed(context);


            //MenuItemEntity newMenu = new MenuItemEntity
            //{
            //    Title="Receive" , Description="Description"
            //};
       
            //context.Menus.Add(newMenu);
            context.SaveChanges();
        }
    }
}
