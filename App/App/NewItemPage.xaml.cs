using Common;
using Common.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewItemPage : ContentPage
    {
        public NewItemPage(MenuItemEntity menuItemEntity)
        {
            InitializeComponent();
            ApiHelper.InitializeClient();
            BindingContextChanged += (_, __) => ItemSubMenuViewModel()?.Reset(menuItemEntity);
            BindingContext = new ItemSubMenuViewModel();
        }

        ItemSubMenuViewModel ItemSubMenuViewModel() => BindingContext as ItemSubMenuViewModel;

        private void SaveRegistration_OnClicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}