using System;
using System.Collections.Generic;
using System.Text;
namespace App_Accurratech.Model
{
    public class Menus
    {
        public List<MenuModel> GetMenus()
        {
            var list = new List<MenuModel>
            {
                new MenuModel
                {
                    Title = "Receive",
                    Description = "This is receive"
                },
                new MenuModel
                {
                    Title = "Shipping",
                    Description = "This is shipping"
                }
            };
            return list;
        }
    }
}
