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
            vm.Load += InitMainNoticeCollection;
            //vm.InitNoticeCollection();
            vm.IsBusy = true;
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