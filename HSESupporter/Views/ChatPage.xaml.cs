using System.Threading.Tasks;
using HSESupporter.Services;
using HSESupporter.Views.Elements;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HSESupporter.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChatPage : ContentPage
    {
        public ChatPage()
        {
            InitializeComponent();

            InitMainNoticeCollection();

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
                Messages.Children.Add(new Message(true)
                    {PAuthor = {Text = message.Author}, PText = {Text = message.Text}, PTime = {Text = "18:18"}});
        }
    }
}