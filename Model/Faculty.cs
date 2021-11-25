using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Model
{
    class Faculty
    {
        public int Id { get; set; }
        public string NameFaculty { get; set; }
        public string ShortNameFaculty { get; set; }
        public Faculty() { }
        public Faculty (int id, string nameFaculty, string snFaculty)
            {
            this.Id = id;
            this.NameFaculty = nameFaculty;
            this.ShortNameFaculty = snFaculty;
            }
    }
}
