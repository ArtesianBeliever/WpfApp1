using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Model
{
    class TeacherDPO
    {
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