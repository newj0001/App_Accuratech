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
using App.ViewModel;
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

            RegistrationValue registrationValue = new RegistrationValue();
            //ICollection<string> fieldValues = new List<string>();
            //var n = 0;
            ICollection<RegistrationValue> registrationValues = new List<RegistrationValue>();
            foreach (var item in ((ListView)SubItemsListView).ItemsSource)
            {
                //var fieldValue = fieldValues.ToList()[n];
                SubItemEntity subItemEntity = (SubItemEntity) item;
                var registrationItem = new RegistrationValue
                {

                    SubItemId = subItemEntity.Id,
                    SubItemEntity = subItemEntity, 
                    Value = registrationValue.Value
                };

                registrationValues.Add(registrationItem);
                //n++;
            }
            var newItemViewModel = new NewItemViewModel();
            await newItemViewModel.Add(registrationValues);
        }
    }
}