using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HSESupporter.Views.Elements
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ImportantNotice : ContentView
    {
        public ImportantNotice()
        {
            InitializeComponent();
        }

        public Label PTitle
        {
            get => Title;
            set => Title = value;
        }
    }
}