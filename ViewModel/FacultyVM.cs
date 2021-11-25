using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;
using System.Collections.ObjectModel;

namespace WpfApp1.ViewModel
{
    class FacultyVM
    {
        public ObservableCollection<Faculty> ListFaculty
        {
            get;
            set;
        } =
     new ObservableCollection<Faculty>();
        public FacultyVM()
        {
            this.ListFaculty.Add(new Faculty
            {
                Id = 1,
                NameFaculty = "Факультет Информационных Технологий",
                ShortNameFaculty  = "ИТ"
            });
            this.ListFaculty.Add(new Faculty
            {
                Id = 2,
                NameFaculty = "Экономический факультет",
                ShortNameFaculty = "ФЭ"
            });
        }
        }
}
