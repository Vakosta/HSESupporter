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
    [DesignTimeVisible(false)]
    public partial class ItemDetailPage : ContentPage
    {
        private readonly ItemDetailViewModel _viewModel;

        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = _viewModel = viewModel;
            _viewModel.Load += InitItem;

            _viewModel.OnLoad();
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

        private async void InitItem(object sender, EventArgs e)
        {
            _viewModel.IsBusy = true;
            try
            {
                var api = new ApiService().HseSupporterApi;
                var result = await api.GetProblem(_viewModel.Item.Id);

                _viewModel.Title = result.Title;
                Title.Text = result.Title;
                Description.Text = result.Description;
                if (result.Status.Equals("O"))
                {
                    InputField.IsVisible = true;
                    Status.Text = "в обработке";
                    Status.BackgroundColor = Color.LightGoldenrodYellow;
                }
                else
                {
                    InputField.IsVisible = false;
                    Status.Text = "обращение закрыто";
                    Status.BackgroundColor = Color.Salmon;
                }

                Messages.Children.Clear();
                foreach (var message in result.Messages)
                    Messages.Children.Add(new Message(Preferences.Get("id", 0)
                        .Equals(message.Author))
                    {
                        PAuthor = {Text = $"{message.AuthorFirstName} {message.AuthorLastName}"},
                        PText = {Text = message.Text}, PTime = {Text = message.CreatedAt.GetDateTimeText()}
                    });

                if (LoadingStatus.IsVisible)
                    LoadingStatus.IsVisible = false;
                if (!Content.IsVisible)
                    Content.IsVisible = true;
            }
            catch (Exception ex)
            {
            }
            finally
            {
                _viewModel.IsBusy = false;
            }
        }

        private async void SendButton_OnClicked(object sender, EventArgs e)
        {
            try
            {
                if (MessageEditor.Text.Equals("")) return;

                var text = MessageEditor.Text;
                MessageEditor.Text = "";

                var firstName = Preferences.Get("first_name", "");
                var lastName = Preferences.Get("last_name", "");
                Messages.Children.Add(new Message(true)
                {
                    PAuthor = {Text = $"{firstName} {lastName}"}, PText = {Text = text},
                    PTime = {Text = DateTime.Now.ToString("HH:mm")}
                });

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