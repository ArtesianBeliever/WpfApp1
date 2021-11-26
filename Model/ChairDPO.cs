using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Model
{
    class ChairDPO
    {
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