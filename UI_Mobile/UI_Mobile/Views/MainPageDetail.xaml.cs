using Common;
using Honeywell.AIDC.CrossPlatform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI_Mobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UI_Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPageDetail : ContentPage
    {
        private string _scannerName;
        private BarcodeReader _barcodeReader = new BarcodeReader(null);

        protected override void OnAppearing()
        {
            //_barcodeReader.BarcodeDataReady += MBarcodeReader_BarcodeDataReady;
        }

        protected override void OnDisappearing()
        {
            _barcodeReader.BarcodeDataReady -= MBarcodeReader_BarcodeDataReady;
        }

        private async void PopulateReaderPicker()
        {
            _barcodeReader = null;
            // Queries the list of readers that are connected to the mobile computer.
            IList<BarcodeReaderInfo> readerList = await BarcodeReader.GetConnectedBarcodeReaders();
            if (readerList.Count > 0)
            {
                foreach (BarcodeReaderInfo reader in readerList)
                {
                    _scannerName = reader.ScannerName;
                }
            }
            else
            {
                _scannerName = "";
            }
        }

        public MainPageDetail(MenuItemEntityModel menuItemEntityModel)
        {
            InitializeComponent();
            ClearText(menuItemEntityModel);
            var fieldItemsViewModel = new FieldItemsViewModel();

            
            fieldItemsViewModel.Reset(menuItemEntityModel);
            BindingContext = fieldItemsViewModel;

            PopulateReaderPicker();
        }
        private void MBarcodeReader_BarcodeDataReady(object sender, BarcodeDataArgs e)
        {

        }
        
        private async void OnItemSelected(object sender, ItemTappedEventArgs e)
        {
            var selectedItem = e.Item as SubItemEntityModel;

            if (!selectedItem.IsFieldEnabledAsBool)
            {
                return;
            }
        }
        private async void SaveClicked(object sender, EventArgs e)
        {
            var subItems = ((ListView)SubItemsListView).ItemsSource;
            foreach (var item in subItems)
            {
                SubItemEntityModel subItemEntity = (SubItemEntityModel)item;
                var fieldItemViewModel = new FieldItemsViewModel(subItemEntity);

                await fieldItemViewModel.AddRegistrationValue(subItemEntity);
            }
        }

        private async void BarcodeReaderButton_Clicked(object sender, EventArgs e)
        {
            var subItems = ((ListView)SubItemsListView).ItemsSource;
            foreach (var item in subItems)
            {
                SubItemEntityModel subItemEntity = (SubItemEntityModel)item;
                await Navigation.PushAsync(new BarcodeReaderPage(subItemEntity));
            }

        }

        public void ClearText(MenuItemEntityModel menuItemEntityModel)
        {
            foreach (var item in menuItemEntityModel.SubItems)
            {
                item.FieldValue = "";
            }
        }
    }
}