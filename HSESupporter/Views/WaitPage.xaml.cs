using System;
using System.Collections.Generic;
using System.IO;
using HSESupporter.Services;
using HSESupporter.ViewModels;
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
            if (!(BindingContext is WaitViewModel vm)) return;

            DormitoryList.ItemsSource = vm.Dormitories;
        }

        private async void SaveButton_OnClicked(object sender, EventArgs e)
        {
            try
            {
                if (DormitoryList.SelectedIndex == -1 || RoomNumber.Text.Equals(""))
                    throw new InvalidDataException();

                var values = new Dictionary<string, object>
                {
                    {"dormitory", DormitoryList.SelectedItem},
                    {"room", RoomNumber.Text}
                };

                LoadingIndicator.IsRunning = true;
                var api = new ApiService().HseSupporterApi;
                var result = await api.SetProfile(values);

                Preferences.Set("dormitory_id", result.Dormitory.Id);

                ResultText.Text = "Сохранено";

                Preferences.Set("is_accept", true);
                await Navigation.PushModalAsync(new MainPage());
            }
            catch (InvalidDataException ex)
            {
                ResultText.Text = "Заполните все поля";
            }
            catch (Exception ex)
            {
                ResultText.Text = "Произошла ошибка";
            }
            finally
            {
                LoadingIndicator.IsRunning = false;
                ResultText.IsVisible = true;
            }
        }
    }
}