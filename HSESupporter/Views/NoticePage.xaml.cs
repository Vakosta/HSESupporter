using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HSESupporter.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NoticePage : ContentPage
    {
        public NoticePage()
        {
            InitializeComponent();
        }

        public Label PTitle
        {
            get => Title;
            set => Title = value;
        }

        public Label PDescription
        {
            get => Description;
            set => Description = value;
        }

        public Label PDate
        {
            get => Date;
            set => Date = value;
        }
    }
}