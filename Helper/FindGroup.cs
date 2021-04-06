using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;

namespace WpfApp1.Helper
{
    class FindGroup
    {
            int id;
            public FindGroup(int id)
            {
                this.id = id;

            }
            public bool PersonPredicate(Group group)
            {
                return group.Id == id;
            }

        }
    }

