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
        private bool _isConfirm;

        public LoginPage()
        {
            InitializeComponent();
        }

        private async void Button_OnClicked(object sender, EventArgs e)
        {
            try
            {
                if (!_isConfirm)
                {
                    var api = new ApiService().HseSupporterApi;

                    var values = new Dictionary<string, object>
                    {
                        {"email", Login.Text},
                    };

                    LoadingIndicator.IsRunning = true;
                    var result = await api.Login(values);
                    LoadingIndicator.IsRunning = false;

                    ResultText.IsVisible = true;
                    ResultText.Text = "Проверочный код отправлен!";

                    Code.IsVisible = true;

                    _isConfirm = true;
                }
                else
                {
                    var api = new ApiService().HseSupporterApi;

                    var values = new Dictionary<string, object>
                    {
                        {"email", Login.Text},
                        {"code", Code.Text}
                    };

                    LoadingIndicator.IsRunning = true;
                    var result = await api.LoginConfirm(values);
                    LoadingIndicator.IsRunning = false;

                    ResultText.IsVisible = true;
                    ResultText.Text = "Успешный вход!";

                    Code.IsVisible = true;

                    Preferences.Set("token", result.Token);
                    Preferences.Set("name", result.Profile.Fio);
                    Preferences.Set("info", result.Profile.Info);

                    await Navigation.PushModalAsync(new MainPage());
                }
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