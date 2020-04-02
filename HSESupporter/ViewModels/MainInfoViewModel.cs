using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
            RefreshCommand = new Command(InitNoticeCollection);
        }

        public Command RefreshCommand { get; set; }

        public List<Notice> AllNotices { get; private set; }
        public ObservableCollection<Notice> Notices { get; }
        public event EventHandler Load;

        public async void InitNoticeCollection()
        {
            Notices.Clear();

            var api = new ApiService().HseSupporterApi;
            AllNotices = await api.GetNotices();

            foreach (var notice in AllNotices.Where(notice => !notice.IsImportant))
                Notices.Add(notice);
            IsBusy = false;
            OnLoad();
        }

        public void OnLoad()
        {
            Load?.Invoke(this, EventArgs.Empty);
        }
    }
}