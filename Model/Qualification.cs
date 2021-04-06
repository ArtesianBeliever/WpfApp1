using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Model
{
    class Qualification
    {
        public int Id { get; set; }
        public string NameQualification { get; set; }
        public Qualification() { }
        public Qualification (int id, string nameQualification)
            {
            this.Id = id;
            this.NameQualification = nameQualification;
            }
    }
}
