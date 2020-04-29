using System;
using System.Collections.Generic;
using HSESupporter.Services;
using HSESupporter.ViewModels;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HSESupporter.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
            if (!(BindingContext is ProfileViewModel vm)) return;

            DormitoryList.ItemsSource = vm.Dormitories;
            DormitoryList.SelectedIndex = vm.Dormitories.IndexOf(Preferences.Get("dormitory_name", ""));
        }

        private async void Button_OnClicked(object sender, EventArgs e)
        {
            try
            {
                var values = new Dictionary<string, object>
                {
                    {"dormitory", DormitoryList.SelectedItem},
                    {"room", RoomNumber.Text}
                };

                LoadingIndicator.IsRunning = true;
                var api = new ApiService().HseSupporterApi;
                var result = await api.SetProfile(values);
                LoadingIndicator.IsRunning = false;

                ResultText.Text = "Сохранено";
                ResultText.IsVisible = true;
            }
            catch (Exception ex)
            {
                LoadingIndicator.IsRunning = false;

                ResultText.Text = "Произошла ошибка";
                ResultText.IsVisible = true;
            }
        }
    }
}