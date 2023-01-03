using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.ViewModel;

namespace WpfApp1.Model
{
    class DisciplineDPO
    {
        public DisciplineDPO ShallowCopy()
        {
            return (DisciplineDPO)this.MemberwiseClone();
        }
        public DisciplineDPO CopyFromTeacher(Discipline discipline)
        {
            DisciplineDPO discDPO = new DisciplineDPO();
            ChairVM vmChair = new ChairVM();
            CurriculumVM vmPost = new CurriculumVM();
            string chair = string.Empty;
            string post = string.Empty;
            foreach (var r in vmChair.ListChair)
            {
                if (r.Id == discipline.IdChair)
                {
                    chair = r.NameChair;
                    break;
                }
            }
            foreach (var q in vmPost.ListCurriculum)
            {
                if (q.Id == discipline.IdCurriculum)
                {
                    post = q.NameCurriculum;
                    break;
                }
            }
            if (chair != string.Empty || post != string.Empty )
            {
                discDPO.Id = discipline.Id;
                discDPO.NameChair = chair;
                discDPO.NameCurriculum = post;
                discDPO.NameDiscipline = discipline.NameDiscipline;
                discDPO.Course = discipline.Course;
                discDPO.Semester = discipline.Semester;
                discDPO.Lecture = discipline.Lecture;
                discDPO.Laboratory = discipline.Practical;
                discDPO.Practical = discipline.Practical;
                discDPO.Examen = discipline.Examen;
                discDPO.SetOff = discipline.SetOff;
            }
            return discDPO;
        }
        public int Id { get; set; }
        public string NameChair { get; set; }
        public string NameCurriculum { get; set; }
        public string NameDiscipline { get; set; }
        public int Course { get; set; }
        public int Semester { get; set; }
        public int Lecture { get; set; }
        public int Laboratory { get; set; }
        public int Practical { get; set; }
        public string Examen { get; set; }
        public string SetOff { get; set; }
        public DisciplineDPO() { }
        public DisciplineDPO(int id, string NameChair, string NamePost, string firstName,
        int course, int semester, int lecture, int laboratory, int practical, string examen, string setOff)
        {
            this.Id = id;
            this.NameChair = NameChair;
            this.NameCurriculum = NamePost;
            this.NameDiscipline = firstName;
            this.Course = course;
            this.Semester = semester;
            this.Lecture = lecture;
            this.Laboratory = laboratory;
            this.Lecture = lecture;
            this.Practical = practical;
            this.Examen = examen;
            this.SetOff = setOff;

        }
    }
}