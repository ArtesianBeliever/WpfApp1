using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApp1.ViewModel;
using WpfApp1.Model;
using WpfApp1.Helper;
using System.Collections.ObjectModel;

namespace WpfApp1.View
{
    /// <summary>
    /// Логика взаимодействия для WindowGroup.xaml
    /// </summary>
    public partial class WindowGroup : Window
    {
        public WindowGroup()
        {
            InitializeComponent();
            GroupVM vmGroup = new GroupVM();
      ///      lvGroup.ItemsSource = vmGroup.ListGroup;
            SpecialityVM vmSpecs = new SpecialityVM();
            QualificationVM vmQuals = new QualificationVM();
            FormEducationVM vmForms = new FormEducationVM();
            List<Speciality> specs = new List<Speciality>();
            List<Qualification> quals = new List<Qualification>();
            List<FormEducation> forms = new List<FormEducation>();
            foreach (Speciality s in vmSpecs.ListSpeciality)
            {
                specs.Add(s);
            }
            foreach (Qualification q in vmQuals.ListQualification)
            {
                quals.Add(q);
            }
            foreach (FormEducation f in vmForms.ListFormEducation)
            {
                forms.Add(f);
            }
            ObservableCollection<GroupDPO> groups = new ObservableCollection<GroupDPO>();
            FindSpec finder1;
            FindQual finder2;
            FindForm finder3;
            foreach (var p in vmGroup.ListGroup)
            {
                finder1 = new FindSpec(p.IdSpeciality);
                Speciality spe = specs.Find(new Predicate<Speciality>(finder1.SpecPredicate));
                finder2 = new FindQual(p.IdQualification);
                Qualification qua = quals.Find(new Predicate<Qualification>(finder2.QualPredicate));
                finder3 = new FindForm(p.IdFormEducation);
                FormEducation forma = forms.Find(new Predicate<FormEducation>(finder3.FormPredicate));
                groups.Add(new GroupDPO
                {
                    Id = p.Id,
                    Speciality = spe.NameSpeciality,
                    Qualification = qua.NameQualification,
                    FormEducation = forma.NameForm,
                    Faculty = p.Faculty,
                    Name = p.Name,
                    Course = p.Course,
                    CountStudent = p.CountStudent,
                    CountSubgroup = p.CountSubgroup
                });
            }
            lvGroup.ItemsSource = groups;

        }
    }
}
