using System.ComponentModel;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace HSESupporter.Views
{
    [DesignTimeVisible(false)]
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            if (Preferences.Get("is_accept", true).Equals(false))
                Navigation.PushModalAsync(new WaitPage());
            else if (Preferences.Get("token", "").Equals(""))
                Navigation.PushModalAsync(new LoginPage());
            else
                InitializeComponent();
        }
    }
}