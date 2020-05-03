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

            InitChatCollection();

            BindingContext = _viewModel = viewModel;
        }

        public ChatPage()
        {
            InitializeComponent();

            InitChatCollection();

            _viewModel = new ChatViewModel();
            BindingContext = _viewModel;
        }

        private async void InitChatCollection()
        {
            try
            {
                var api = new ApiService().HseSupporterApi;
                var result = await api.GetDormitory(1);
                var messages = result.Messages;

                foreach (var message in messages)
                    Messages.Children.Add(new Message(Preferences.Get("id", 0)
                        .Equals(message.Author))
                    {
                        PAuthor = {Text = $"{message.AuthorFirstName} {message.AuthorLastName}"},
                        PText = {Text = message.Text}, PTime = {Text = message.CreatedAt.GetDateTimeText()}
                    });

                await Task.Delay(50);
                await ScrollView.ScrollToAsync(0,
                    StackLayout.Children.LastOrDefault().Y,
                    false);
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

        private async void Button_OnClicked(object sender, EventArgs e)
        {
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
        }
    }
}