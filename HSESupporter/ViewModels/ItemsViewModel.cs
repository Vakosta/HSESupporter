using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using HSESupporter.Models;
using HSESupporter.Services;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace HSESupporter.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public ItemsViewModel()
        {
            Title = "Проблемы";
            Items = new ObservableCollection<Problem>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        public ObservableCollection<Problem> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        private async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();

                var api = new ApiService().HseSupporterApi;
                var items = await api.GetProblems($"Token {Preferences.Get("token", "")}");
                foreach (var item in items) Items.Add(item);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}