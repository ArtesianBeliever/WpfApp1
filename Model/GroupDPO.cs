using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.ViewModel;

namespace WpfApp1.Model
{
    class GroupDPO
    {
        public GroupDPO ShallowCopy()
        {
            return (GroupDPO)this.MemberwiseClone();
        }
        public GroupDPO CopyFromGroup(Group group)
        {
            GroupDPO grDPO = new GroupDPO();
            SpecialityVM vmSpec = new SpecialityVM();
            QualificationVM vmQual = new QualificationVM();
            FormEducationVM vmForm = new FormEducationVM();
            string spec = string.Empty;
            string qual = string.Empty;
            string form = string.Empty;
            foreach (var r in vmSpec.ListSpeciality)
            {
                if (r.Id == group.IdSpeciality)
                {
                    spec = r.NameSpeciality;
                    break;
                }
            }
            foreach (var q in vmQual.ListQualification)
            {
                if (q.Id == group.IdQualification)
                {
                    qual = q.NameQualification;
                    break;
                }
            }
            foreach (var f in vmForm.ListFormEducation)
            {
                if (f.Id == group.IdFormEducation)
                {
                    form = f.NameForm;
                    break;
                }
            }
            if (spec != string.Empty || qual != string.Empty || form != string.Empty)
            {
                grDPO.Id = group.Id;
                grDPO.Speciality = spec;
                grDPO.Qualification = qual;
                grDPO.FormEducation = form;
                grDPO.Faculty = group.Faculty;
                grDPO.Name = group.Name;
                grDPO.Course = group.Course;
                grDPO.CountStudent = group.CountStudent;
                grDPO.CountSubgroup = group.CountSubgroup;
            }
            return grDPO;
        }
        public int Id { get; set; }
        public string Speciality { get; set; }
        public string Qualification { get; set; }
        public string FormEducation { get; set; }
        public string Faculty { get; set; }
        public string Name { get; set; }
        public int Course { get; set; }
        public int CountStudent { get; set; }
        public int CountSubgroup { get; set; }
        public GroupDPO() { }
        public GroupDPO(int id, string Speciality, string Qualification, string FormEducation, string faculty,
        string name, int course, int countStudent, int countSubgroup)
        {
            this.Id = id;
            this.Speciality = Speciality;
            this.Qualification = Qualification;
            this.FormEducation = FormEducation;
            this.Faculty = faculty;
            this.Name = name;
            this.Course = course;
            this.CountStudent = countStudent;
            this.CountSubgroup = countSubgroup;

        }
    }
}
