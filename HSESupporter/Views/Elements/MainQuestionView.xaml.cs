using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HSESupporter.Views.Elements
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainQuestionView : ContentView
    {
        public MainQuestionView()
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