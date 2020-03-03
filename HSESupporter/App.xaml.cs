using HSESupporter.Services;
using HSESupporter.Views;
using Xamarin.Forms;

namespace HSESupporter
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}