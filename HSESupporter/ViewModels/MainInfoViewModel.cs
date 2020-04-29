using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using HSESupporter.Models;
using HSESupporter.Services;
using Xamarin.Forms;

namespace HSESupporter.ViewModels
{
    public sealed class MainInfoViewModel : BaseViewModel
    {
        public MainInfoViewModel()
        {
            Title = "Главная";
            Notices = new ObservableCollection<Notice>();
            RefreshCommand = new Command(Init);
        }

        public Command RefreshCommand { get; set; }

        public Profile Profile { get; private set; }
        public List<Notice> AllNotices { get; private set; }
        public ObservableCollection<Notice> Notices { get; }
        public event EventHandler Load;

        public async void Init()
        {
            await InitProfile();
            await InitNoticeCollection();

            IsBusy = false;

            OnLoad();
        }

        public async Task InitProfile()
        {
            var api = new ApiService().HseSupporterApi;
            Profile = await api.GetProfile();
        }

        public async Task InitNoticeCollection()
        {
            Notices.Clear();

            var api = new ApiService().HseSupporterApi;
            AllNotices = await api.GetNotices();

            foreach (var notice in AllNotices.Where(notice => !notice.IsImportant))
                Notices.Add(notice);
        }

        public void OnLoad()
        {
            Load?.Invoke(this, EventArgs.Empty);
        }
    }
}