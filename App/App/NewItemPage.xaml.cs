using Common;
using Common.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
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
            //BindingContextChanged += (_, __) => MainWindowViewModel()?.Reset(menuItemEntity);
            //BindingContext = new MainWindowViewModel();
        }

        //MainWindowViewModel MainWindowViewModel() => BindingContext as MainWindowViewModel;
        public NewItemViewModel NewItemViewModel => BindingContext as NewItemViewModel;

        private async void BtnSaveRegistration_Click(object sender, EventArgs e)
        {
            await NewItemViewModel.AddRegistration();
            await NewItemViewModel.AddRegistrationValue();
        }
    }
}