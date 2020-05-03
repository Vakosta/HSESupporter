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
                    Preferences.Set("is_accept", result.IsAccept);
                    Preferences.Set("id", result.Profile.Id);
                    Preferences.Set("first_name", result.Profile.FirstName);
                    Preferences.Set("last_name", result.Profile.LastName);
                    Preferences.Set("dormitory_id", result.Profile.Dormitory.Id);
                    Preferences.Set("info", result.Profile.Info);
                    Preferences.Set("is_student", result.Profile.Role.Equals("student"));

                    if (result.IsAccept)
                        await Navigation.PushModalAsync(new MainPage());
                    else
                        await Navigation.PushModalAsync(new WaitPage());
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