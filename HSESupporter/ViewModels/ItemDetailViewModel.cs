using HSESupporter.Models;

namespace HSESupporter.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public ItemDetailViewModel(Problem item = null)
        {
            Title = item?.Title;
            Item = item;
        }

        public Problem Item { get; set; }
    }
}