using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Model
{
    class Curriculum
    {
        public Curriculum ShallowCopy()
        {
            return (Curriculum)this.MemberwiseClone();
        }
        public int Id { get; set; }
        public string NameCurriculum { get; set; }
        public int AcademicYear { get; set; }
        public string Speciality { get; set; }
        public string Qualification { get; set; }
        public string FormEducation { get; set; }
        public int Course { get; set; }
        public Curriculum() { }
        public Curriculum(int id, string nameCurriculum, int academicYear, string specialtiy, string qualification,
            string formEducation, int course)
        {
            this.Id = id;
            this.NameCurriculum = nameCurriculum;
            this.AcademicYear = academicYear;
            this.Speciality = specialtiy;
            this.Qualification = qualification;
            this.FormEducation = formEducation;
            this.Course = course;
        }
    }
}