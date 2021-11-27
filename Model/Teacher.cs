using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.ViewModel;

namespace WpfApp1.Model
{
    class Teacher
    {
        public Teacher CopyFromTeacherDPO(TeacherDPO p)
        {
            ChairVM vmChair = new ChairVM();
            PostVM vmPost = new PostVM();
   //         FormEducationVM vmForm = new FormEducationVM();
            int chairId = 0;
            int postId = 0;
     //      int formId = 0;
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
                if (q.NamePost == p.NamePost)
                {
                    postId = q.Id;
                    break;
                }
            }
   //        foreach (var f in vmForm.ListFormEducation)
    //        {
      //          if (f.NameForm == p.FormEducation)
        //        {
          //          formId = f.Id;
            //        break;
              //  }
            //}
            if (chairId != 0 || postId != 0)
            {
                this.Id = p.Id;
                this.IdChair = IdChair;
                this.IdPost = IdPost;
                this.FirstName = p.FirstName;
                this.SecondName = p.SecondName;
                this.LastName = p.LastName;
                this.Phone = p.Phone;
                this.EMail = p.EMail;
        //        this.CountSubgroup = p.CountSubgroup;
            }
            return this;
        }

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