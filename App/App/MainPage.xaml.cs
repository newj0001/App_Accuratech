using Common;
using Common.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Xamarin.Forms;

namespace App
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    { 
        public MainPage()
        {
            InitializeComponent();
            ApiHelper.InitializeClient();
            BindingContextChanged += async (_, __) => await ItemMenuViewModel?.Reset();
            BindingContext = new MainWindowViewModel();
        }

        MainWindowViewModel ItemMenuViewModel => BindingContext as MainWindowViewModel;

        async private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var selectedItem = e.Item as MenuItemEntity;

            await Navigation.PushAsync(new NewItemPage(selectedItem));

            ((ListView)sender).SelectedItem = null;
        }
    }
}
