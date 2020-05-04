using System;
using System.ComponentModel;
using HSESupporter.Models;
using HSESupporter.Services;
using HSESupporter.ViewModels;
using Xamarin.Forms;

namespace HSESupporter.Views
{
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
            await Navigation.PushAsync(new NewItemPage());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            _viewModel.LoadItemsCommand.Execute(null);
        }

        private async void MenuItem_OnDelete(object sender, EventArgs e)
        {
            try
            {
                var problem = ((MenuItem) sender).BindingContext as Problem;
                var api = new ApiService().HseSupporterApi;

                if (problem == null) return;
                await api.DeleteProblem(problem.Id);

                ItemsListView.BeginRefresh();
            }
            catch (Exception ex)
            {
                // Empty
            }
        }
    }
}