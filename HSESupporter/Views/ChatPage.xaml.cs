using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using HSESupporter.Services;
using HSESupporter.ViewModels;
using HSESupporter.Views.Elements;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HSESupporter.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChatPage : ContentPage
    {
        private readonly ChatViewModel _viewModel;

        public ChatPage(ChatViewModel viewModel)
        {
            InitializeComponent();

            InitChatCollection(true);

            BindingContext = _viewModel = viewModel;
        }

        public ChatPage()
        {
            InitializeComponent();

            InitChatCollection(true);

            _viewModel = new ChatViewModel();
            BindingContext = _viewModel;
        }

        private async Task InitChatCollection(bool isScrollDown)
        {
            try
            {
                var api = new ApiService().HseSupporterApi;
                var result = await api.GetDormitory(1);
                var messages = result.Messages;

                Messages.Children.Clear();

                foreach (var message in messages)
                    Messages.Children.Add(new Message(Preferences.Get("id", 0)
                        .Equals(message.Author))
                    {
                        PAuthor = {Text = $"{message.AuthorFirstName} {message.AuthorLastName}"},
                        PText = {Text = message.Text}, PTime = {Text = message.CreatedAt.GetDateTimeText()}
                    });

                if (isScrollDown)
                {
                    await Task.Delay(50);
                    await ScrollView.ScrollToAsync(0,
                        StackLayout.Children.LastOrDefault().Y,
                        false);
                }
            }
            catch (HttpRequestException e)
            {
                // TODO: Возникла ошибка при подключении к сайту.
            }
            catch (Exception e)
            {
                // TODO: Возникла неизвестная ошибка.
            }
        }

        private async void SendButton_OnClicked(object sender, EventArgs e)
        {
            SendButton.IsVisible = false;
            LoadingIndicatorSend.IsVisible = true;
            LoadingIndicatorSend.IsRunning = true;

            try
            {
                if (MessageEditor.Text.Equals("")) return;

                var text = MessageEditor.Text;
                MessageEditor.Text = "";

                var firstName = Preferences.Get("first_name", "");
                var lastName = Preferences.Get("last_name", "");

                var message = new Models.Message
                {
                    IsRead = false,
                    IsFromStudent = true,
                    Dormitory = 1,
                    Text = text
                };

                var api = new ApiService().HseSupporterApi;
                await api.SendMessage(message.GetDictionaryParams());

                Messages.Children.Add(new Message(true)
                {
                    PAuthor = {Text = $"{firstName} {lastName}"}, PText = {Text = text},
                    PTime = {Text = DateTime.Now.ToString("HH:mm")}
                });

                await Task.Delay(1);
                await ScrollView.ScrollToAsync(StackLayout.Children.LastOrDefault(),
                    ScrollToPosition.MakeVisible,
                    false);
            }
            catch (Exception ex)
            {
                // Nothing
            }

            LoadingIndicatorSend.IsVisible = false;
            LoadingIndicatorSend.IsRunning = false;
            SendButton.IsVisible = true;
        }

        private async void Refresh_OnTapped(object sender, EventArgs e)
        {
            RefreshButton.IsVisible = false;
            LoadingIndicatorRefresh.IsVisible = true;
            LoadingIndicatorRefresh.IsRunning = true;

            await InitChatCollection(true);

            await Task.Delay(1);
            await ScrollView.ScrollToAsync(StackLayout.Children.LastOrDefault(),
                ScrollToPosition.MakeVisible,
                false);

            LoadingIndicatorRefresh.IsVisible = false;
            LoadingIndicatorRefresh.IsRunning = false;
            RefreshButton.IsVisible = true;
        }
    }
}