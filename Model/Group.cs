using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Model
{
    class Teacher
    {
        public int Id { get; set; }
        public int IdChair { get; set; }
        public int IdPost { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string EMail { get; set; }
        public Teacher() { }
        public Teacher(int id, int idChair, int idPost, string firstName,
        string secondName, string lastName, string phone, string email)
        {
            this.Id = id;
            this.IdChair = idChair;
            this.IdPost = idPost;
            this.FirstName = firstName;
            this.SecondName = secondName;
            this.LastName = lastName;
            this.Phone = phone;
            this.EMail = email;

        }
    }
}