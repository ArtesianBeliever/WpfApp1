using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.ViewModel;

namespace WpfApp1.Model
{
    class Discipline
    {
        public Discipline CopyFromTeacherDPO(DisciplineDPO p)
        {
            ChairVM vmChair = new ChairVM();
            CurriculumVM vmPost = new CurriculumVM();
            int chairId = 0;
            int postId = 0;
            foreach (var s in vmChair.ListChair)
            {
                if (s.NameChair == p.NameChair)
                {
                    chairId = s.Id;
                    break;
                }
            }
            foreach (var q in vmPost.ListPost)
            {
                if (q.NameCurriculum == p.NameCurriculum)
                {
                    postId = q.Id;
                    break;
                }
            }
            if (chairId != 0 || postId != 0)
            {
                this.Id = p.Id;
                this.IdChair = IdChair;
                this.IdCurriculum = IdCurriculum;
                this.NameDiscipline = p.NameDiscipline;
                this.Course = p.Course;
                this.Semester = p.Semester;
                this.Lecture = p.Lecture;
                this.Laboratory = p.Laboratory;
                this.Practical = p.Practical;
                this.Examen = p.Examen;
                this.SetOff = p.SetOff;
            }
            return this;
        }

        public int Id { get; set; }
        public int IdChair { get; set; }
        public int IdCurriculum { get; set; }
        public string NameDiscipline { get; set; }
        public int Course { get; set; }
        public int Semester { get; set; }
        public int Lecture { get; set; }
        public int Laboratory { get; set; }
        public int Practical { get; set; }
        public bool Examen { get; set; }
        public bool SetOff { get; set; }

        public Discipline() { }
        public Discipline(int id, int idChair, int idCurriculum, string nameDiscipline,
        int course, int semester, int lecture, int laboratory, int practical, bool examen, bool setOff)
        {
            this.Id = id;
            this.IdChair = idChair;
            this.IdCurriculum = idCurriculum;
            this.NameDiscipline = nameDiscipline;
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