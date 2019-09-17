using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Common;
using Common.ViewModel;
using UI_Mobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UI_Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuItemsView : ContentPage
    {
        public MenuItemsView()
        {
            InitializeComponent();
            var menuItemsViewModel = new MenuItemsViewModel();
            menuItemsViewModel.Reset();
            BindingContext = menuItemsViewModel;
        }

        private async void OnItemSelected(object sender, ItemTappedEventArgs e)
        {
            var selectedItem = e.Item as MenuItemEntityModel;
            if (!selectedItem.IsMenuEnabledAsBool)
            {
                return;
            }
            
            await Navigation.PushAsync(new FieldItemsView(selectedItem));
            ((ListView) sender).SelectedItem = null;
        }
    }
}