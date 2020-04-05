using Xamarin.Forms;

namespace HSESupporter.Views.Elements
{
    public partial class Message : ContentView
    {
        public Message(bool isFromStudent)
        {
            InitializeComponent();

            if (isFromStudent)
                Margin = new Thickness(42, 0, -8, 0);
            else
                Margin = new Thickness(-8, 0, 42, 0);
        }

        public Label PText
        {
            get => Title;
            set => Title = value;
        }

        public Label PTime
        {
            get => Time;
            set => Time = value;
        }
    }
}