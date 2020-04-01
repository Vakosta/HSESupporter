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

            var importantNotice = new ImportantNotice {PTitle = {Text = "KekCheburek"}};
            StackImportantMessages.Children.Add(importantNotice);
        }
    }
}