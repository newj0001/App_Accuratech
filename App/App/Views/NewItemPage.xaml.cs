using Common;
using Common.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ListView = Xamarin.Forms.ListView;

namespace App
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewItemPage : ContentPage
    {
        public NewItemPage(MenuItemEntity menuItemEntity)
        {
            InitializeComponent();
            ApiHelper.InitializeClient();
            BindingContextChanged += (_, __) => MainWindowViewModel?.Reset(menuItemEntity);
            BindingContext = new MainWindowViewModel();

       }

        MainWindowViewModel MainWindowViewModel => BindingContext as MainWindowViewModel;

        private async void SaveClicked(object sender, EventArgs e)
        {
            var subItems = ((ListView)SubItemsListView).ItemsSource;

            foreach (var item in subItems)
            {
                SubItemEntity subItemEntity = (SubItemEntity)item;
                var newItemViewModel = new NewItemViewModel(subItemEntity);
                await newItemViewModel.AddRegistrationValue((item as SubItemEntity)?.FieldValue);
            }
        }
    }
}