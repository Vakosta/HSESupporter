using System.Collections.Generic;
using System.Collections.ObjectModel;
using HSESupporter.Models;

namespace HSESupporter.ViewModels
{
    public class MainInfoViewModel
    {
        private readonly IList<Notice> _source;

        public MainInfoViewModel()
        {
            _source = new List<Notice>();
            InitNoticeCollection();
        }

        public ObservableCollection<Notice> Notices { get; private set; }

        private void InitNoticeCollection()
        {
            _source.Add(new Notice
            {
                Title = "Kek",
                Description = "Cheburek"
            });
            _source.Add(new Notice
            {
                Title = "Lol",
                Description = "Arbidol"
            });
            _source.Add(new Notice
            {
                Title = "Gi",
                Description = "Gigigigi"
            });

            Notices = new ObservableCollection<Notice>(_source);
        }
    }
}