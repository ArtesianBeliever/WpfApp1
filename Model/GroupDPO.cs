using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Model
{
    class GroupDPO
    {
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
