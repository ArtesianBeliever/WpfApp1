using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.ViewModel;

namespace WpfApp1.Model
{
    class TeacherDPO
    {
        public TeacherDPO ShallowCopy()
        {
            return (TeacherDPO)this.MemberwiseClone();
        }
        public TeacherDPO CopyFromTeacher(Teacher teacher)
        {
            TeacherDPO teachDPO = new TeacherDPO();
            ChairVM vmChair = new ChairVM();
            PostVM vmPost = new PostVM();
            string chair = string.Empty;
            string post = string.Empty;
            foreach (var r in vmChair.ListChair)
            {
                if (r.Id == teacher.IdChair)
                {
                    chair = r.NameChair;
                    break;
                }
            }
            foreach (var q in vmPost.ListPost)
            {
                if (q.Id == teacher.IdPost)
                {
                    post = q.NamePost;
                    break;
                }
            }
            if (chair != string.Empty || post != string.Empty )
            {
                teachDPO.Id = teacher.Id;
                teachDPO.NameChair = chair;
                teachDPO.NamePost = post;
                teachDPO.FirstName = teacher.FirstName;
                teachDPO.SecondName = teacher.SecondName;
                teachDPO.LastName = teacher.LastName;
                teachDPO.Phone = teacher.Phone;
                teachDPO.EMail = teacher.EMail;
            }
            return teachDPO;
        }
        public int Id { get; set; }
        public string NameChair { get; set; }
        public string NamePost { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string EMail { get; set; }
        public TeacherDPO() { }
        public TeacherDPO(int id, string NameChair, string NamePost, string firstName,
        string secondName, string lastName, string phone, string email)
        {
            this.Id = id;
            this.NameChair = NameChair;
            this.NamePost = NamePost;
            this.FirstName = firstName;
            this.SecondName = secondName;
            this.LastName = lastName;
            this.Phone = phone;
            this.EMail = email;

        }
    }
}