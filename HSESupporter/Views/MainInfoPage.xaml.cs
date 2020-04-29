using System;
using System.Linq;
using HSESupporter.ViewModels;
using HSESupporter.Views.Elements;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HSESupporter.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainInfoPage : ContentPage
    {
        public MainInfoPage()
        {
            InitializeComponent();

            if (!(BindingContext is MainInfoViewModel vm)) return;
            vm.Load += InitProfile;
            vm.Load += InitMainNoticeCollection;

            vm.IsBusy = true;
        }

        private void InitProfile(object sender, EventArgs e)
        {
            if (!(BindingContext is MainInfoViewModel vm)) return;

            Name.Text = $"{vm.Profile.FirstName} {vm.Profile.LastName}";
            DormitoryName.Text = vm.Profile.Dormitory.Name;
            DormitoryAddress.Text = vm.Profile.Dormitory.Address;
        }

        private void InitMainNoticeCollection(object sender, EventArgs e)
        {
            StackImportantMessages.Children.Clear();

            if (!(BindingContext is MainInfoViewModel vm)) return;
            var importantNotices = vm.AllNotices.Where(notice => notice.IsImportant);

            foreach (var notice in importantNotices)
                StackImportantMessages.Children.Add(new ImportantNotice {PTitle = {Text = notice.Title}});
        }

        private async void MenuItem_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProfilePage());
        }
    }
}