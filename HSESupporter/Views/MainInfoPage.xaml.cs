using System;
using System.Linq;
using HSESupporter.ViewModels;
using HSESupporter.Views.Elements;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HSESupporter.Views
{
    /// <summary>
    /// Класс главной страницы приложения.
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainInfoPage : ContentPage
    {
        public MainInfoPage()
        {
            InitializeComponent();
            if (!(BindingContext is MainInfoViewModel vm)) return;

            vm.Load += InitProfile;
            vm.Load += InitMainNoticeCollection;
            vm.Load += InitEvents;
            vm.Load += InitMainQuestions;

            vm.Error += OnError;

            vm.IsBusy = true;
        }

        /// <summary>
        /// Инициализирует блок с профилем пользователя.
        /// </summary>
        private void InitProfile(object sender, EventArgs e)
        {
            if (LoadingStatus.IsVisible)
                LoadingStatus.IsVisible = false;

            if (!EventsTitle.IsVisible)
                EventsTitle.IsVisible = true;

            if (!MainQuestionsTitle.IsVisible)
                MainQuestionsTitle.IsVisible = true;

            if (!(BindingContext is MainInfoViewModel vm)) return;

            Name.Text = $"{vm.Profile.FirstName} {vm.Profile.LastName}";
            DormitoryName.Text = vm.Profile.Dormitory.Name;
            DormitoryAddress.Text = vm.Profile.Dormitory.Address;

            Preferences.Set("id", vm.Profile.Id);
            Preferences.Set("first_name", vm.Profile.FirstName);
            Preferences.Set("last_name", vm.Profile.LastName);
            Preferences.Set("dormitory_name", vm.Profile.Dormitory.Name);
            Preferences.Set("room", vm.Profile.Room);
        }

        /// <summary>
        /// Инициализирует блок с главными сообщениями.
        /// </summary>
        private void InitMainNoticeCollection(object sender, EventArgs e)
        {
            StackImportantMessages.Children.Clear();

            if (!(BindingContext is MainInfoViewModel vm)) return;
            var importantNotices = vm.AllNotices.Where(notice => notice.IsImportant);

            foreach (var notice in importantNotices)
                StackImportantMessages.Children.Add(new ImportantNotice {PTitle = {Text = notice.Title}});
        }

        /// <summary>
        /// Инициализирует блок с событиями.
        /// </summary>
        private void InitEvents(object sender, EventArgs e)
        {
            Events.Children.Clear();

            if (!(BindingContext is MainInfoViewModel vm)) return;
            foreach (var eEvent in vm.Events)
                Events.Children.Add(new EventView
                {
                    PTitle =
                    {
                        Text = eEvent.Title
                    },
                    PTargetDate = eEvent.TargetDate
                });
        }

        /// <summary>
        /// Инициализирует блок с главными вопросами.
        /// </summary>
        private void InitMainQuestions(object sender, EventArgs e)
        {
            MainQuestions.Children.Clear();

            if (!(BindingContext is MainInfoViewModel vm)) return;
            foreach (var mainQuestion in vm.MainQuestions)
            {
                var mainQuestionView = new MainQuestionView
                {
                    PTitle = {Text = mainQuestion.Question},
                    Answer = mainQuestion.Answer
                };

                mainQuestionView.Click += async (o, args) =>
                {
                    await DisplayAlert("Ответ", mainQuestionView.Answer, "OK");
                };

                MainQuestions.Children.Add(mainQuestionView);
            }
        }

        /// <summary>
        /// Вызывается при возникновении ошибки.
        /// </summary>
        private void OnError(object sender, EventArgs e)
        {
            Console.WriteLine();
        }

        /// <summary>
        /// Открывает страницу с профилем.
        /// </summary>
        private async void MenuItem_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProfilePage());
        }
    }
}