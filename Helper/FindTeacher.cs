using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;

namespace WpfApp1.Helper
{
    class FindTeacher
    {
        int id;
        public FindTeacher(int id)
        {
            this.id = id;

        }
        public bool PersonPredicate(Teacher teacher)
        {
            return teacher.Id == id;
        }

    }
}
