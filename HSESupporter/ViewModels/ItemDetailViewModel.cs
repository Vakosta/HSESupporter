using System;
using HSESupporter.Models;
using Xamarin.Forms;

namespace HSESupporter.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public ItemDetailViewModel(Problem item = null)
        {
            Title = item?.Title;
            Item = item;

            RefreshCommand = new Command(InitItem);
        }

        public Command RefreshCommand { get; set; }

        public Problem Item { get; set; }

        public event EventHandler Load;

        private void InitItem()
        {
            OnLoad();
        }

        public void OnLoad()
        {
            Load?.Invoke(this, EventArgs.Empty);
        }
    }
}