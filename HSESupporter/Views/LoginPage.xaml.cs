using System;
using System.Collections.Generic;
using HSESupporter.Services;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HSESupporter.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void Button_OnClicked(object sender, EventArgs e)
        {
            try
            {
                var api = new ApiService().HseSupporterApi;

                var values = new Dictionary<string, object>
                {
                    {"username", Login.Text},
                    {"password", Password.Text}
                };

                LoadingIndicator.IsRunning = true;
                var result = await api.Login(values);
                LoadingIndicator.IsRunning = false;

                ResultText.IsVisible = true;
                ResultText.Text = "Успешный вход!";

                Preferences.Set("token", result.Token);

                await Navigation.PushModalAsync(new ItemsPage());
            }
            catch (Exception ex)
            {
                LoadingIndicator.IsRunning = false;

                ResultText.IsVisible = true;
                ResultText.Text = "Произошла ошибка.";
            }
        }
    }
}