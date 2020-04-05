using System;
using HSESupporter.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HSESupporter.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChatPage : ContentPage
    {
        public ChatPage()
        {
            InitializeComponent();

            if (!(BindingContext is MainInfoViewModel vm)) return;
            vm.Load += InitMainNoticeCollection;
            //vm.InitNoticeCollection();
            vm.IsBusy = true;
        }

        private void InitMainNoticeCollection(object sender, EventArgs e)
        {
        }
    }
}