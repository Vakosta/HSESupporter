using System;
using HSESupporter.Services;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HSESupporter.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WaitPage : ContentPage
    {
        public WaitPage()
        {
            InitializeComponent();
        }

        private async void CheckButton_OnClicked(object sender, EventArgs e)
        {
            try
            {
                LoadingIndicator.IsRunning = true;

                var api = new ApiService().HseSupporterApi;
                var result = await api.CheckAcceptStatus();

                LoadingIndicator.IsRunning = false;

                Preferences.Set("is_accept", result.IsAccept);
                if (result.IsAccept)
                    await Navigation.PushModalAsync(new MainPage());
            }
            catch (Exception ex)
            {
                // Nothing yet
            }
        }
    }
}