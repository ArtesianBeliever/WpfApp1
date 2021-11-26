using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Model
{
    class Chair
    {
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