using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.ViewModel;

namespace WpfApp1.Model
{
    class ChairDPO
    {
        public ChairDPO ShallowCopy()
        {
            return (ChairDPO)this.MemberwiseClone();
        }
        public ChairDPO CopyFromChair(Chair chair)
        {
            ChairDPO chDPO = new ChairDPO();
            FacultyVM vmFaculty = new FacultyVM();
            string faculty = string.Empty;
            foreach (var r in vmFaculty.ListFaculty)
            {
                if (r.Id == chair.IdFaculty)
                {
                    faculty = r.NameFaculty;
                    break;
                }
            }


            if (faculty != string.Empty )
            {
                chDPO.Id = chair.Id;
                chDPO.NameFaculty = faculty;
                chDPO.NameChair = chair.NameChair;
                chDPO.ShortNameChair = chair.ShortNameChair;
            }
            return chDPO;
        }
        public int Id { get; set; }
        public string NameFaculty { get; set; }
        public string NameChair { get; set; }
        public string ShortNameChair { get; set; }
        public ChairDPO() { }
        public ChairDPO(int id, string NameFaculty, string nameChair, string snChair)
        {
            this.Id = id;
            this.NameFaculty = NameFaculty;
            this.NameChair = nameChair;
            this.ShortNameChair = snChair;
        }
    }
}