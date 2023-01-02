using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;

namespace WpfApp1.Helper
{
    class FindDiscipline
    {
        int id;
        public FindDiscipline(int id)
        {
            this.id = id;

        }
        public bool PersonPredicate(Discipline discipline)
        {
            return discipline.Id == id;
        }

    }
}
