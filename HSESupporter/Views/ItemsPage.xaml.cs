using System;
using System.ComponentModel;
using HSESupporter.Models;
using HSESupporter.ViewModels;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace HSESupporter.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ItemsPage : ContentPage
    {
        private readonly ItemsViewModel _viewModel;

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new ItemsViewModel();
        }

        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Problem;
            if (item == null)
                return;

            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));

            // Manually deselect item.
            ItemsListView.SelectedItem = null;
        }

        private async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewItemPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (Preferences.Get("token", "").Equals(""))
                Navigation.PushModalAsync(new LoginPage());

            if (_viewModel.Items.Count == 0)
                _viewModel.LoadItemsCommand.Execute(null);
        }
    }
}