using System;
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

        public string Answer { get; set; }

        public event EventHandler Click;

        private void TapGestureRecognizer_OnTapped(object sender, EventArgs e)
        {
            OnClick();
        }

        public void OnClick()
        {
            Click?.Invoke(this, EventArgs.Empty);
        }
    }
}