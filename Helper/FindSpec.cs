using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;

namespace WpfApp1.Helper
{
    class FindSpec
    {
        int id;
        public FindSpec(int id)
        {
            this.id = id;
        }
        public bool SpecPredicate(Speciality speciality)
        {
            return speciality.Id == id;
        }
    }
}
