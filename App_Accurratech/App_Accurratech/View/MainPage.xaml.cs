using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App_Accurratech.ViewModel;
using Library;

namespace App_Accurratech
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
            BindingContext = new MobileMenuViewModel();
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            (sender as ListView).SelectedItem = null;

            if (e.SelectedItem != null)
            {
                MobileMenuViewModel menuData = e.SelectedItem as MobileMenuViewModel;
            }
        }
    }
}
