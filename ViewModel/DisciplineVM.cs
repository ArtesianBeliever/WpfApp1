using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;
using System.Collections.ObjectModel;

namespace WpfApp1.ViewModel
{
    class DisciplineVM
    {
        public int MaxId()
        {
            int max = 0;
            foreach (var r in this.ListDiscipline)
            {
                if (max < r.Id)
                {
                    max = r.Id;
                };
            }
            return max;
        }
        public ObservableCollection<Discipline> ListDiscipline
        {
            get;
            set;
        } =
 new ObservableCollection<Discipline>();
        public DisciplineVM()
        {
            this.ListDiscipline.Add(
            new Discipline
            {
                Id = 1,
                IdChair = 1,
                IdCurriculum = 1,
                NameDiscipline = "Интернет-Маркетинг",
                Course = 1,
                Semester = 1,
                Lecture = 3,
                Laboratory=5,
                Practical=3,
                Examen = "Да",
                SetOff = "Нет",
            });
            this.ListDiscipline.Add(
            new Discipline
            {
                Id = 2,
                IdChair = 3,
                IdCurriculum = 2,
                NameDiscipline = "Бухгалтерский учет",
                Course = 1,
                Semester = 1,
                Lecture = 2,
                Laboratory = 2,
                Practical = 3,
                Examen = "Да",
                SetOff = "Нет",
            });
            this.ListDiscipline.Add(
            new Discipline
            {
                Id = 3,
                IdChair = 1,
                IdCurriculum = 1,
                NameDiscipline = "Информационно-аналитические системы",
                Course = 1,
                Semester = 1,
                Lecture = 2,
                Laboratory = 2,
                Practical = 5,
                Examen = "Нет",
                SetOff = "Да",
            });
        }
    }
}