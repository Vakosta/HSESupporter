using System.ComponentModel;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace HSESupporter.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            if (Preferences.Get("token", "").Equals(""))
                Navigation.PushModalAsync(new LoginPage());
            else
                InitializeComponent();
        }
    }
}