using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;
using System.Collections.ObjectModel;

namespace WpfApp1.ViewModel
{
    class QualificationVM
    {
        public int MaxIdQ()
        {
            int max = 0;
            foreach (var s in this.ListQualification)
            {
                if (max < s.Id)
                {
                    max = s.Id;
                };
            }
            return max;
        }
        public ObservableCollection<Qualification> ListQualification
        {
            get;
            set;
        } =
     new ObservableCollection<Qualification>();
        public QualificationVM()
        {
            this.ListQualification.Add(new Qualification
            {
                Id = 1,
                NameQualification = "Специалист"
            });
            this.ListQualification.Add(new Qualification
            {
                Id = 2,
                NameQualification = "Академический бакалавр"
            });
            this.ListQualification.Add(new Qualification
            {
                Id = 3,
                NameQualification = "Прикладной бакалавр"
            });
        }
        }
}
