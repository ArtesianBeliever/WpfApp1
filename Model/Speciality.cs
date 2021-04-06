using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Model
{
    class Speciality
    {
        public int Id { get; set; }
        public string NameSpeciality { get; set; }
        public string Profile { get; set; }
        public Speciality() { }
        public Speciality(int id, string nameSpeciality, string profile)
        {
            this.Id = id;
            this.NameSpeciality = nameSpeciality;
            this.Profile = profile;
        }
    }
}
