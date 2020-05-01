using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using HSESupporter.Models;
using HSESupporter.Services;
using Xamarin.Forms;

namespace HSESupporter.ViewModels
{
    public sealed class MainInfoViewModel : BaseViewModel
    {
        public enum ErrorType
        {
            NetworkError,
            ServerError,
            UnknownError
        }

        public MainInfoViewModel()
        {
            Title = "Главная";
            Notices = new ObservableCollection<Notice>();
            Events = new ObservableCollection<Event>();
            MainQuestions = new ObservableCollection<MainQuestion>();

            RefreshCommand = new Command(InitMainPage);
        }

        public Command RefreshCommand { get; set; }

        public Profile Profile { get; private set; }
        public List<Notice> AllNotices { get; private set; }
        public ObservableCollection<Notice> Notices { get; }
        public ObservableCollection<Event> Events { get; }
        public ObservableCollection<MainQuestion> MainQuestions { get; }

        public event EventHandler Load;
        public event EventHandler Error;

        public async void InitMainPage()
        {
            try
            {
                var api = new ApiService().HseSupporterApi;
                var mainPage = await api.GetMainPage();

                Notices.Clear();
                Events.Clear();
                MainQuestions.Clear();

                AllNotices = mainPage.Notices;

                Profile = mainPage.Profile;
                foreach (var notice in mainPage.Notices.Where(notice => !notice.IsImportant))
                    Notices.Add(notice);
                foreach (var eEvent in mainPage.Events)
                    Events.Add(eEvent);
                foreach (var mainQuestion in mainPage.MainQuestions)
                    MainQuestions.Add(mainQuestion);

                IsBusy = false;
                OnLoad();
            }
            catch (HttpRequestException e)
            {
                OnError(ErrorType.ServerError);
            }
            catch (Exception e)
            {
                OnError(ErrorType.UnknownError);
            }
        }

        public void OnLoad()
        {
            Load?.Invoke(this, EventArgs.Empty);
        }

        public void OnError(ErrorType type)
        {
            Error?.Invoke(this, EventArgs.Empty);
        }
    }
}