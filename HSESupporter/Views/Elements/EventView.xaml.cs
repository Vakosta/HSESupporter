using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HSESupporter.Views.Elements
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EventView : ContentView
    {
        public EventView()
        {
            InitializeComponent();
        }

        public Label PTitle
        {
            get => Title;
            set => Title = value;
        }

        public string PTargetDate
        {
            set
            {
                var dateTime = DateTime.Parse(value);

                DateNumber.Text = dateTime.Day.ToString();
                switch (dateTime.Month)
                {
                    case 1:
                        DateMonth.Text = "ЯНВ";
                        break;
                    case 2:
                        DateMonth.Text = "ФЕВ";
                        break;
                    case 3:
                        DateMonth.Text = "МАР";
                        break;
                    case 4:
                        DateMonth.Text = "АПР";
                        break;
                    case 5:
                        DateMonth.Text = "МАЙ";
                        break;
                    case 6:
                        DateMonth.Text = "ИЮН";
                        break;
                    case 7:
                        DateMonth.Text = "ИЮЛ";
                        break;
                    case 8:
                        DateMonth.Text = "АВГ";
                        break;
                    case 9:
                        DateMonth.Text = "СЕН";
                        break;
                    case 10:
                        DateMonth.Text = "ОКТ";
                        break;
                    case 11:
                        DateMonth.Text = "НОЯ";
                        break;
                    default:
                        DateMonth.Text = "ДЕК";
                        break;
                }
            }
        }
    }
}