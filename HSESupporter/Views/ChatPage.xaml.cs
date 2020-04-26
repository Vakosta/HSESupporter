using System;
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

            InitMainNoticeCollection();

            BindingContext = _viewModel = viewModel;

            Device.BeginInvokeOnMainThread(async () =>
            {
                if (Device.RuntimePlatform == Device.Android)
                {
                    await ScrollView.ScrollToAsync(0, Messages.Height, true);
                }
                else
                {
                    await Task.Delay(10); //UI will be updated by Xamarin
                    await ScrollView.ScrollToAsync(Messages, ScrollToPosition.End, true);
                }
            });
        }

        public ChatPage()
        {
            InitializeComponent();

            InitMainNoticeCollection();

            _viewModel = new ChatViewModel();
            BindingContext = _viewModel;

            Device.BeginInvokeOnMainThread(async () =>
            {
                if (Device.RuntimePlatform == Device.Android)
                {
                    await ScrollView.ScrollToAsync(0, Messages.Height, true);
                }
                else
                {
                    await Task.Delay(10); //UI will be updated by Xamarin
                    await ScrollView.ScrollToAsync(Messages, ScrollToPosition.End, true);
                }
            });
        }

        private async void InitMainNoticeCollection()
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
        }

        private async void Button_OnClicked(object sender, EventArgs e)
        {
            try
            {
                if (MessageEditor.Text.Equals("")) return;

                var text = MessageEditor.Text;
                MessageEditor.Text = "";

                var fio = Preferences.Get("name", "").Split(' ');
                Messages.Children.Add(new Message(true)
                {
                    PAuthor = {Text = $"{fio[1]} {fio[0]}"}, PText = {Text = text},
                    PTime = {Text = DateTime.Now.ToString("HH:mm")}
                });

                var message = new Models.Message
                {
                    IsRead = false,
                    IsFromStudent = true,
                    Dormitory = 1,
                    Text = text
                };

                var api = new ApiService().HseSupporterApi;
                await api.SendMessage(message.GetDictionaryParams());
            }
            catch (Exception ex)
            {
                // Nothing
            }
        }
    }
}