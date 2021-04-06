using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;

namespace WpfApp1.Helper
{
    class FindQual
    {
        int id;
        public FindQual(int id)
        {
            this.id = id;
        }
        public bool QualPredicate(Qualification qualification)
        {
            return qualification.Id == id;
        }
    }
}
