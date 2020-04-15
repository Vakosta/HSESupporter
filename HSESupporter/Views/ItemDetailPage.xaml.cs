using System;
using System.ComponentModel;
using HSESupporter.Models;
using HSESupporter.Services;
using HSESupporter.ViewModels;
using Xamarin.Essentials;
using Xamarin.Forms;
using Message = HSESupporter.Views.Elements.Message;

namespace HSESupporter.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ItemDetailPage : ContentPage
    {
        private readonly ItemDetailViewModel _viewModel;

        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = _viewModel = viewModel;

            foreach (var message in _viewModel.Item.Messages)
                Messages.Children.Add(new Message(Preferences.Get("id", 0)
                    .Equals(message.Author))
                {
                    PAuthor = {Text = $"{message.AuthorFirstName} {message.AuthorLastName}"},
                    PText = {Text = message.Text}, PTime = {Text = "18:18"}
                });
        }

        public ItemDetailPage()
        {
            InitializeComponent();

            var item = new Problem
            {
                Title = "Item 1",
                Description = "This is an item description."
            };

            _viewModel = new ItemDetailViewModel(item);
            BindingContext = _viewModel;
        }

        private async void Button_OnClicked(object sender, EventArgs e)
        {
            try
            {
                if (MessageEditor.Text.Equals("")) return;

                var text = MessageEditor.Text;
                MessageEditor.Text = "";

                var fio = Preferences.Get("name", "").Split(' ');
                Messages.Children.Add(new Message(true)
                    {PAuthor = {Text = $"{fio[1]} {fio[0]}"}, PText = {Text = text}, PTime = {Text = "18:18"}});

                var message = new Models.Message
                {
                    Author = 1,
                    IsRead = false,
                    IsFromStudent = true,
                    Text = text,
                    Problem = _viewModel.Item.Id
                };

                var api = new ApiService().HseSupporterApi;
                await api.SendMessage(message.GetDictionaryParams());
            }
            catch (Exception ex)
            {
                // Nothing
            }
        }
    }
}