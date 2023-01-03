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
    public partial class WindowDiscipline : Window
    {
        private DisciplineVM vmTeach;
        private ChairVM vmChair;
        private CurriculumVM vmPost;
        private ObservableCollection<DisciplineDPO> teachDPO;
        private List<Chair> chairs;
        private List<Curriculum> currs;

        public WindowDiscipline()
        {
            InitializeComponent();
            vmTeach = new DisciplineVM();
            vmChair = new ChairVM();
            vmPost = new CurriculumVM();
            chairs = vmChair.ListChair.ToList();
            currs = vmPost.ListCurriculum.ToList();
            foreach (Curriculum curriculum in currs)
            {
                MessageBox.Show(curriculum.NameCurriculum);
            }
            // Формирование данных для отображения сотрудников с должностями
            // на базе коллекции класса ListPerson<Person>
            teachDPO = new ObservableCollection<DisciplineDPO>();
            foreach (var teacher in vmTeach.ListDiscipline)
            {
                DisciplineDPO p = new DisciplineDPO();
                p = p.CopyFromTeacher(teacher);
                teachDPO.Add(p);
            }
            lvGroup.ItemsSource = teachDPO;
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            NewDiscipline wnEmployee = new NewDiscipline
            {
                Title = "Новая Дисциплина",
                Owner = this
            };
            // формирование кода нового сотрудника
            int maxIdPerson = vmTeach.MaxId() + 1;
            DisciplineDPO gr = new DisciplineDPO
            {
                Id = maxIdPerson,
            };
            wnEmployee.DataContext = gr;
            wnEmployee.CbChair.ItemsSource = chairs;
            wnEmployee.CbPost.ItemsSource = currs;

            if (wnEmployee.ShowDialog() == true)
            {
                Chair s = (Chair)wnEmployee.CbChair.SelectedValue;
                gr.NameChair = s.NameChair;
                Curriculum q = (Curriculum)wnEmployee.CbPost.SelectedValue;
                gr.NameCurriculum = q.NameCurriculum;

                teachDPO.Add(gr);
                Discipline p = new Discipline();
                p = p.CopyFromTeacherDPO(gr);
                vmTeach.ListDiscipline.Add(p);
            }
        }
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            NewDiscipline wnEmployee = new NewDiscipline
            {
                Title = "Редактирование данных",
                Owner = this
            };
            DisciplineDPO perDPO = (DisciplineDPO)lvGroup.SelectedValue;
            DisciplineDPO tempPerDPO; // временный класс для редактирования
            if (perDPO != null)
            {
                tempPerDPO = perDPO.ShallowCopy();
                wnEmployee.DataContext = tempPerDPO;
                wnEmployee.CbChair.ItemsSource = chairs;
                wnEmployee.CbChair.Text = tempPerDPO.NameChair;
                wnEmployee.CbPost.ItemsSource = currs;
                wnEmployee.CbPost.Text = tempPerDPO.NameCurriculum;
                if (wnEmployee.ShowDialog() == true)
                {
                    // перенос данных из временного класса в класс отображения данных
                    Chair r = (Chair)wnEmployee.CbChair.SelectedValue;
                    perDPO.NameChair = r.NameChair;
                    Curriculum q = (Curriculum)wnEmployee.CbPost.SelectedValue;
                    perDPO.NameCurriculum = q.NameCurriculum;
                    perDPO.NameDiscipline = tempPerDPO.NameDiscipline;
                    perDPO.Course = tempPerDPO.Course;
                    perDPO.Semester = tempPerDPO.Semester;
                    perDPO.Lecture = tempPerDPO.Lecture;
                    perDPO.Laboratory = tempPerDPO.Laboratory;
                    perDPO.Practical = tempPerDPO.Practical;
                    perDPO.Examen = tempPerDPO.Examen;
                    perDPO.SetOff = tempPerDPO.SetOff;
                    lvGroup.ItemsSource = null;
                    lvGroup.ItemsSource = teachDPO;
                    // перенос данных из класса отображения данных в класс Person
                    FindDiscipline finder = new FindDiscipline(perDPO.Id);
                    List<Discipline> listPerson = vmTeach.ListDiscipline.ToList();
                    Discipline p = listPerson.Find(new Predicate<Discipline>(finder.PersonPredicate));
                    p = p.CopyFromTeacherDPO(perDPO);
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать дисциплину для редактированния",
                "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            DisciplineDPO person = (DisciplineDPO)lvGroup.SelectedItem;
            if (person != null)
            {
                MessageBoxResult result = MessageBox.Show("Удалить данные о дисциплине: \n" + person.NameDiscipline,
                "Предупреждение", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                if (result == MessageBoxResult.OK)
                {
                    // удаление данных в списке отображения данных
                    teachDPO.Remove(person);
                    Discipline per = new Discipline();
                    per = per.CopyFromTeacherDPO(person);
                    vmTeach.ListDiscipline.Remove(per);
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать данные дисциплины для удаления",
                "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

    }
}