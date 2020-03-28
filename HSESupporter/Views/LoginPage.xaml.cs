using System;
using System.Collections.Generic;
using HSESupporter.Services;
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
                var api = new ApiService().hseSupporterApi;

                var values = new Dictionary<string, object>
                {
                    {"username", "Vakosta"},
                    {"password", "..."}
                };

                var result = await api.Login(values);
                Console.Write(result.Token);
            }
            catch (Exception ex)
            {
                // Nothing
            }
        }
    }
}