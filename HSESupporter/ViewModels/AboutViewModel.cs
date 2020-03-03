using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace HSESupporter.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "О приложении";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://xamarin.com"));
        }

        public ICommand OpenWebCommand { get; }
    }
}