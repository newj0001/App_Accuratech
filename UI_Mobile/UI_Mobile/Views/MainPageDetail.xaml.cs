using Common;
using Common.Services;
using Honeywell.AIDC.CrossPlatform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UI_Mobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UI_Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPageDetail : ContentPage
    {
        private readonly RegistrationValueDataStore _registrationValueDataStore;
        private readonly SubItemEntityModel _parentSubItem;

        private const string DEFAULT_READER_KEY = "default";
        private Dictionary<string, BarcodeReader> mBarcodeReaders;
        private bool mContinuousScan = false, mOpenReader = false;
        private BarcodeReader mSelectedReader = null;
        private SynchronizationContext mUIContext = SynchronizationContext.Current;
        private int mTotalContinuousScanCount = 0;
        private bool mSoftContinuousScanStarted = false;
        private bool mSoftOneShotScanStarted = false;
        private string deviceModel = null;
        private BarcodeReaderInfo reader;
        private string _scannerName;


        public MainPageDetail(MenuItemEntityModel menuItemEntityModel)
        {
            InitializeComponent();
            ClearText(menuItemEntityModel);
            var fieldItemsViewModel = new FieldItemsViewModel();
            fieldItemsViewModel.Reset(menuItemEntityModel);
            BindingContext = fieldItemsViewModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

        }

        protected override void OnDisappearing()
        {
            //_barcodeReader.BarcodeDataReady -= MBarcodeReader_BarcodeDataReady;
        }

        private async void PopulateReader()
        {
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

        public event EventHandler NewRegistrationValueCreated;
    }
}