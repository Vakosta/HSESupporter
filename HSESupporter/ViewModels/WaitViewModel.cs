using System.Collections;
using System.Collections.Generic;

namespace HSESupporter.ViewModels
{
    public class WaitViewModel : BaseViewModel
    {
        public readonly IList Dormitories = new List<string>
        {
            "Общежитие №1",
            "Общежитие №2",
            "Общежитие №3",
            "Общежитие №4",
            "Общежитие №5",
            "Общежитие №6",
            "Общежитие №7",
            "Общежитие №8 «Трилистник»",
            "Общежитие №9",
            "Общежитие №10",
            "Общежитие №11",
            "Студенческий городок Дубки"
        };

        public WaitViewModel()
        {
            Title = "Профиль";
        }
    }
}