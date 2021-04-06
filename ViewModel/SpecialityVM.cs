using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;
using System.Collections.ObjectModel;

namespace WpfApp1.ViewModel
{
    class SpecialityVM
    {
        public int MaxIdS()
        {
            int max = 0;
            foreach (var s in this.ListSpeciality)
            {
                if (max < s.Id)
                {
                    max = s.Id;
                };
            }
            return max;
        }
        public ObservableCollection<Speciality> ListSpeciality
            {
                get;
                set;
            } =
     new ObservableCollection<Speciality>();
        public SpecialityVM()
        {
            this.ListSpeciality.Add(new Speciality
            {
                Id = 1,
                NameSpeciality = "Прикладная Информатика",
                Profile = "Программист"
            });
            this.ListSpeciality.Add(new Speciality
            {
                Id = 2,
                NameSpeciality = "Программная инженерия",
                Profile = "Инженер"
            });
            this.ListSpeciality.Add(new Speciality
            {
                Id = 3,
                NameSpeciality = "Компьютерные сети",
                Profile = "Инженер сетей"
            });
        }
            }

}
