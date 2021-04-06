using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;
using System.Collections.ObjectModel;

namespace WpfApp1.ViewModel
{
    class GroupVM
    {
        public int MaxId()
        {
            int max = 0;
            foreach (var r in this.ListGroup)
            {
                if (max < r.Id)
                {
                    max = r.Id;
                };
            }
            return max;
        }

        public ObservableCollection<Group> ListGroup
        {
            get;
            set;
        } =
 new ObservableCollection<Group>();
 public GroupVM()
        {
            this.ListGroup.Add(
            new Group
            {
                Id = 1,
                IdSpeciality = 1,
                IdQualification = 1,
                IdFormEducation = 1,
                Faculty = "KTiIB",
                Name = "PIZS-321",
                Course = 2,
                CountStudent = 21,
                CountSubgroup = 1
            });
            this.ListGroup.Add(
            new Group
            {
                Id = 2,
                IdSpeciality = 2,
                IdQualification = 3,
                IdFormEducation = 2,
                Faculty = "KTiIB",
                Name = "PRIZS-321",
                Course = 2,
                CountStudent = 24,
                CountSubgroup = 2
            });
            this.ListGroup.Add(
            new Group
            {
                Id = 3,
                IdSpeciality = 3,
                IdQualification = 2,
                IdFormEducation = 2,
                Faculty = "KTiIB",
                Name = "PIZ-321",
                Course = 2,
                CountStudent = 11,
                CountSubgroup = 2
            });
        }
    }
}
