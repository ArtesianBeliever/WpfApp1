using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;
using System.Collections.ObjectModel;

namespace WpfApp1.ViewModel
{
    class CurriculumVM
    {
        public int MaxIdQ()
        {
            int max = 0;
            foreach (var s in this.ListCurriculum)
            {
                if (max < s.Id)
                {
                    max = s.Id;
                };
            }
            return max;
        }
        public ObservableCollection<Curriculum> ListCurriculum
        {
            get;
            set;
        } =
    new ObservableCollection<Curriculum>();
        public CurriculumVM()
        {
            this.ListCurriculum.Add(new Curriculum
            {
                Id = 1,
                NameCurriculum = "09.04.03 - Прикладная информатика",
                AcademicYear = 2020,
                Speciality = "Прикладная Информатика",
                Qualification = "Программист",
                FormEducation = "Заочная",
                Course = 1
            });
            this.ListCurriculum.Add(new Curriculum
            {
                Id = 2,
                NameCurriculum = "38.04.01 - Экономика",
                AcademicYear = 2022,
                Speciality = "Экономика",
                Qualification = "Экономист",
                FormEducation = "Очная",
                Course = 2
            });
        }
    }
}