using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;
using System.Collections.ObjectModel;

namespace WpfApp1.ViewModel
{
    class FormEducationVM
    {
        public int MaxIdF()
        {
            int max = 0;
            foreach (var s in this.ListFormEducation)
            {
                if (max < s.Id)
                {
                    max = s.Id;
                };
            }
            return max;
        }
        public ObservableCollection<FormEducation> ListFormEducation
        {
            get;
            set;
        } =
    new ObservableCollection<FormEducation>();
        public FormEducationVM()
        {
            this.ListFormEducation.Add(new FormEducation
            {
                Id = 1,
                NameForm = "Очная"
            });
            this.ListFormEducation.Add(new FormEducation
            {
                Id = 2,
                NameForm = "Заочная"
            });
        }
    }
}
