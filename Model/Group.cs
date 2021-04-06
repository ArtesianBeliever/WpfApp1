using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.ViewModel;

namespace WpfApp1.Model
{
    class Group
    {
        public Group CopyFromPersonDPO(GroupDPO p)
        {
            SpecialityVM vmSpec = new SpecialityVM();
            QualificationVM vmQual = new QualificationVM();
            FormEducationVM vmForm = new FormEducationVM();
            int specId = 0;
            int qualId = 0;
            int formId = 0;
            foreach (var s in vmSpec.ListSpeciality)
            {
                if (s.NameSpeciality == p.Speciality)
                {
                specId = s.Id;
                    break;
                }
            }
            foreach (var q in vmQual.ListQualification)
            {
                if (q.NameQualification == p.Qualification)
                {
                    qualId = q.Id;
                    break;
                }
            }
            foreach (var f in vmForm.ListFormEducation)
            {
                if (f.NameForm == p.FormEducation)
                {
                    formId = f.Id;
                    break;
                }
            }
            if (specId != 0 || formId != 0 || qualId!=0)
            {
                this.Id = p.Id;
                this.IdSpeciality = IdSpeciality;
                this.IdQualification = IdQualification;
                this.IdFormEducation = IdFormEducation;
                this.Faculty = p.Faculty;
                this.Name = p.Name;
                this.Course = p.Course;
                this.CountStudent = p.CountStudent;
                this.CountSubgroup = p.CountSubgroup;
            }
            return this;
        }

        public int Id { get; set; }
        public int IdSpeciality { get; set; }
        public int IdQualification { get; set; }
        public int IdFormEducation { get; set; }
        public string Faculty { get; set; }
        public string Name { get; set; }
        public int Course { get; set; }
        public int CountStudent { get; set;}
        public int CountSubgroup { get; set; }
        public Group() { }
        public Group(int id, int idSpeciality, int idQualification, int idFormEducation, string faculty,
        string name, int course, int countStudent, int countSubgroup)
        {
            this.Id = id;
            this.IdSpeciality = idSpeciality;
            this.IdQualification = idQualification;
            this.IdFormEducation = idFormEducation;
            this.Faculty = faculty;
            this.Name = name;
            this.Course = course;
            this.CountStudent = countStudent;
            this.CountSubgroup = countSubgroup;

        }
    }
}
