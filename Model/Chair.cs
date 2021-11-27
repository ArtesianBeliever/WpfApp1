using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.ViewModel;

namespace WpfApp1.Model
{
    class Chair
    {
        public Chair CopyFromChairDPO(ChairDPO p)
        {
            FacultyVM vmFac = new FacultyVM();
   //         PostVM vmPost = new PostVM();
            //         FormEducationVM vmForm = new FormEducationVM();
            int facId = 0;
///            int postId = 0;
            //      int formId = 0;
            foreach (var s in vmFac.ListFaculty)
            {
                if (s.NameFaculty == p.NameFaculty)
                {
                    facId = s.Id;
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
            if (facId != 0 )
            {
                this.Id = p.Id;
                this.IdFaculty = IdFaculty;
                this.NameChair = p.NameChair;
                this.ShortNameChair = p.ShortNameChair;
                //        this.CountSubgroup = p.CountSubgroup;
            }
            return this;
        }
        public int Id { get; set; }
        public int IdFaculty { get; set; }
        public string NameChair { get; set; }
        public string ShortNameChair { get; set; }
        public Chair() { }
        public Chair(int id, int idFaculty, string nameChair, string snChair)
        {
            this.Id = id;
            this.IdFaculty = idFaculty;
            this.NameChair = nameChair;
            this.ShortNameChair = snChair;
        }
    }
}