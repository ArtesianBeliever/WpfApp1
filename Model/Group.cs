using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Model
{
    class Group
    {
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
