using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Model
{
    class FormEducation
    {
        public FormEducation ShallowCopy()
        {
            return (FormEducation)this.MemberwiseClone();
        }
        public int Id { get; set; }
        public string NameForm { get; set; }
        public FormEducation ( ) { }
        public FormEducation ( int id, string nameForm)
        {
            this.Id = id;
            this.NameForm = nameForm;
        }
    }
}
