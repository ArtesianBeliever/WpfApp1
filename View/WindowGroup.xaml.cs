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
        private GroupVM vmGroup;
        private SpecialityVM vmSpec;
        private QualificationVM vmQual;
        private FormEducationVM vmForm;
        private ObservableCollection<GroupDPO> grDPO;
        private List<Speciality> specs;
        private List<Qualification> quals;
        private List<FormEducation> forms;

        public WindowGroup()
        {
            InitializeComponent();
            vmGroup = new GroupVM();
            vmSpec = new SpecialityVM();
            vmQual = new QualificationVM();
            vmForm = new FormEducationVM();
            specs = vmSpec.ListSpeciality.ToList();
            quals = vmQual.ListQualification.ToList();
            forms = vmForm.ListFormEducation.ToList();
            // Формирование данных для отображения сотрудников с должностями
            // на базе коллекции класса ListPerson<Person>
            grDPO = new ObservableCollection<GroupDPO>();
            foreach (var group in vmGroup.ListGroup)
            {
                GroupDPO p = new GroupDPO();
                p = p.CopyFromGroup(group);
                grDPO.Add(p);
            }
            lvGroup.ItemsSource = grDPO;
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            NewGroup wnEmployee = new NewGroup
            {
                Title = "Новая группа",
                Owner = this
            };
            // формирование кода нового собрудника
            int maxIdPerson = vmGroup.MaxId() + 1;
            GroupDPO gr = new GroupDPO
            {
                Id = maxIdPerson,
            };
            wnEmployee.DataContext = gr;
            wnEmployee.CbSpec.ItemsSource = specs;
            wnEmployee.CbQual.ItemsSource = quals;
            wnEmployee.CbForm.ItemsSource = forms;
            if (wnEmployee.ShowDialog() == true)
            {
                Speciality s = (Speciality)wnEmployee.CbSpec.SelectedValue;
                gr.Speciality = s.NameSpeciality;
                Qualification q = (Qualification)wnEmployee.CbQual.SelectedValue;
                gr.Qualification = q.NameQualification;
                FormEducation f = (FormEducation)wnEmployee.CbForm.SelectedValue;
                gr.FormEducation = f.NameForm;
                grDPO.Add(gr);
                Group p = new Group();
                p = p.CopyFromPersonDPO(gr);
                vmGroup.ListGroup.Add(p);
            }
        }
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            NewGroup wnEmployee = new NewGroup
            {
                Title = "Редактирование данных",
                Owner = this
            };
            GroupDPO perDPO = (GroupDPO)lvGroup.SelectedValue;
            GroupDPO tempPerDPO; // временный класс для редактирования
            if (perDPO != null)
            {
                tempPerDPO = perDPO.ShallowCopy();
                wnEmployee.DataContext = tempPerDPO;
                wnEmployee.CbSpec.ItemsSource = specs;
                wnEmployee.CbSpec.Text = tempPerDPO.Speciality;
                wnEmployee.CbQual.ItemsSource = quals;
                wnEmployee.CbQual.Text = tempPerDPO.Qualification;
                wnEmployee.CbForm.ItemsSource = forms;
                wnEmployee.CbForm.Text = tempPerDPO.FormEducation;
                if (wnEmployee.ShowDialog() == true)
                {
                    // перенос данных из временного класса в класс отображения данных
                    Speciality r = (Speciality)wnEmployee.CbSpec.SelectedValue;
                    perDPO.Speciality = r.NameSpeciality;
                    Qualification q = (Qualification)wnEmployee.CbQual.SelectedValue;
                    perDPO.Qualification = q.NameQualification;
                    FormEducation f = (FormEducation)wnEmployee.CbForm.SelectedValue;
                    perDPO.FormEducation = f.NameForm;
                    perDPO.Faculty = tempPerDPO.Faculty;
                    perDPO.Name = tempPerDPO.Name;
                    perDPO.Course = tempPerDPO.Course;
                    lvGroup.ItemsSource = null;
                lvGroup.ItemsSource = grDPO;
                    // перенос данных из класса отображения данных в класс Person
                    FindGroup finder = new FindGroup(perDPO.Id);
                    List<Group> listPerson = vmGroup.ListGroup.ToList();
                    Group p = listPerson.Find(new Predicate<Group>(finder.PersonPredicate));
                    p = p.CopyFromPersonDPO(perDPO);
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать сотрудника для редактированния",
                "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            GroupDPO person = (GroupDPO)lvGroup.SelectedItem;
            if (person != null)
            {
                MessageBoxResult result = MessageBox.Show("Удалить данные группы: \n" + person.Name + " " ,
                "Предупреждение", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                if (result == MessageBoxResult.OK)
                {
                    // удаление данных в списке отображения данных
                    grDPO.Remove(person);
                    // удаление данных в списке классов ListPerson<Person>
                    Group per = new Group();
                    per = per.CopyFromPersonDPO(person);
                    vmGroup.ListGroup.Remove(per);
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать данные группы для удаления",
                "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

    }
}
