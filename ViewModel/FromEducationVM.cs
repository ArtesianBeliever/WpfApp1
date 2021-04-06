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
        public ObservableCollection<FormEducation> ListQualification
        {
            get;
            set;
        } =
    new ObservableCollection<FormEducation>();
        public FormEducationVM()
        {
            this.ListQualification.Add(new FormEducation
            {
                Id = 1,
                NameForm = "Очная"
            });
            this.ListQualification.Add(new FormEducation
            {
                Id = 2,
                NameForm = "Заочная"
            });
        }
    }
}
