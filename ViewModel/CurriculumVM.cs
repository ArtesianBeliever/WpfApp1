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
            foreach (var s in this.ListPost)
            {
                if (max < s.Id)
                {
                    max = s.Id;
                };
            }
            return max;
        }
        public ObservableCollection<Curriculum> ListPost
        {
            get;
            set;
        } =
    new ObservableCollection<Curriculum>();
        public CurriculumVM()
        {
            this.ListPost.Add(new Curriculum
            {
                Id = 1,
                NameCurriculum = "Прикладная информатика в экономике",
                AcademicYear = 2020,
                Speciality = "Прикладная Информатика",
                Qualification = "Пусто",
                FormEducation = "не пусто",
                Course = 1
            });
            this.ListPost.Add(new Curriculum
            {
                Id = 2,
                NameCurriculum = "Прикладная информатика в не экономике",
                AcademicYear = 2020,
                Speciality = "Прикладная Информатика",
                Qualification = "очень пусто",
                FormEducation = "не пусто",
                Course = 1
            });
        }
    }
}