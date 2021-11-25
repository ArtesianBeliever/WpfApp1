using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;
using System.Collections.ObjectModel;

namespace WpfApp1.ViewModel
{
    class ChairVM
    {
            public ObservableCollection<Chair> ListChair
            {
                get;
                set;
            } =
     new ObservableCollection<Chair>();
        public ChairVM()
        {
            this.ListChair.Add(new Chair
            {
                Id = 1,
                IdFaculty = 1,
                NameChair = "Кафедра Компьютерных Технологий и Информационной безопасности",
                ShortNameChair = "КТиБ"
            });
            this.ListChair.Add(new Chair
            {
                Id = 2,
                IdFaculty = 2,
                NameChair = "Кафедра Права",
                ShortNameChair = "КП"
            });
            this.ListChair.Add(new Chair
            {
                Id = 3,
                IdFaculty = 2,
                NameChair = "Кафедра Экономики и Финансов",
                ShortNameChair = "КЭФ"
            });
        }
            }
}
