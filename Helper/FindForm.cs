using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;

namespace WpfApp1.Helper
{
    class FindForm
    {
        int id;
        public FindForm(int id)
        {
            this.id = id;
        }
        public bool FormPredicate(FormEducation formEducation)
        {
            return formEducation.Id == id;
        }
    }
}
