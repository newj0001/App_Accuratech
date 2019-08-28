using Common;
using Common.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using App.ViewModel;
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
            BindingContextChanged += (_, __) => MainWindowViewModel?.Reset(menuItemEntity);
            BindingContext = new MainWindowViewModel();
        }

        public NewItemPage()
        {
            InitializeComponent();
            ApiHelper.InitializeClient();
            BindingContextChanged += (_, __) => MainWindowViewModel?.Reset();
            BindingContext = new MainWindowViewModel();
        }

        MainWindowViewModel MainWindowViewModel => BindingContext as MainWindowViewModel;

        private async void SaveClicked(object sender, EventArgs e)
        {
            
            ICollection<RegistrationValue> registrationValues = new List<RegistrationValue>();
            ICollection<SubItemEntity> subItemEntities = new List<SubItemEntity>();

            foreach (var subItemEntity in subItemEntities)
            {
                var registrationItem = new RegistrationValue
                {
                    
                    SubItemId = subItemEntity.Id,
                    SubItemEntity = subItemEntity,
                    Value = FieldValue,
                    
                };
            }

            

            var newItemViewModel = new NewItemViewModel();

            
            await newItemViewModel.Add(registrationValues);
        }
    }
}