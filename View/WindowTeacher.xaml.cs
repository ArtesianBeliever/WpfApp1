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
        private TeacherVM vmTeach;
        private ChairVM vmChair;
        private PostVM vmPost;
        private ObservableCollection<TeacherDPO> teachDPO;
        private List<Chair> chairs;
        private List<Post> posts;

        public WindowGroup()
        {
            InitializeComponent();
            vmTeach = new TeacherVM();
            vmChair = new ChairVM();
            vmPost = new PostVM();
            chairs = vmChair.ListChair.ToList();
            posts = vmPost.ListPost.ToList();
            // Формирование данных для отображения сотрудников с должностями
            // на базе коллекции класса ListPerson<Person>
            teachDPO = new ObservableCollection<TeacherDPO>();
            foreach (var teacher in vmTeach.ListTeacher)
            {
                TeacherDPO p = new TeacherDPO();
                p = p.CopyFromTeacher(teacher);
                teachDPO.Add(p);
            }
            lvGroup.ItemsSource = teachDPO;
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            NewTeach wnEmployee = new NewTeach
            {
                Title = "Новый преподаватель",
                Owner = this
            };
            // формирование кода нового сотрудника
            int maxIdPerson = vmTeach.MaxId() + 1;
            TeacherDPO gr = new TeacherDPO
            {
                Id = maxIdPerson,
            };
            wnEmployee.DataContext = gr;
            wnEmployee.CbChair.ItemsSource = chairs;
            wnEmployee.CbPost.ItemsSource = posts;

            if (wnEmployee.ShowDialog() == true)
            {
                Chair s = (Chair)wnEmployee.CbChair.SelectedValue;
                gr.NameChair = s.NameChair;
                Post q = (Post)wnEmployee.CbPost.SelectedValue;
                gr.NamePost = q.NamePost;

                teachDPO.Add(gr);
                Teacher p = new Teacher();
                p = p.CopyFromTeacherDPO(gr);
                vmTeach.ListTeacher.Add(p);
            }
        }
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            NewTeach wnEmployee = new NewTeach
            {
                Title = "Редактирование данных",
                Owner = this
            };
            TeacherDPO perDPO = (TeacherDPO)lvGroup.SelectedValue;
            TeacherDPO tempPerDPO; // временный класс для редактирования
            if (perDPO != null)
            {
                tempPerDPO = perDPO.ShallowCopy();
                wnEmployee.DataContext = tempPerDPO;
                wnEmployee.CbChair.ItemsSource = chairs;
                wnEmployee.CbChair.Text = tempPerDPO.NameChair;
                wnEmployee.CbPost.ItemsSource = posts;
                wnEmployee.CbPost.Text = tempPerDPO.NamePost;
                if (wnEmployee.ShowDialog() == true)
                {
                    // перенос данных из временного класса в класс отображения данных
                    Chair r = (Chair)wnEmployee.CbChair.SelectedValue;
                    perDPO.NameChair = r.NameChair;
                    Post q = (Post)wnEmployee.CbPost.SelectedValue;
                    perDPO.NamePost = q.NamePost;
                    perDPO.FirstName = tempPerDPO.FirstName;
                    perDPO.SecondName = tempPerDPO.SecondName;
                    perDPO.LastName = tempPerDPO.LastName;
                    perDPO.Phone = tempPerDPO.Phone;
                    perDPO.EMail = tempPerDPO.EMail;
                    lvGroup.ItemsSource = null;
                    lvGroup.ItemsSource = teachDPO;
                    // перенос данных из класса отображения данных в класс Person
                    FindTeacher finder = new FindTeacher(perDPO.Id);
                    List<Teacher> listPerson = vmTeach.ListTeacher.ToList();
                    Teacher p = listPerson.Find(new Predicate<Teacher>(finder.PersonPredicate));
                    p = p.CopyFromTeacherDPO(perDPO);
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
            TeacherDPO person = (TeacherDPO)lvGroup.SelectedItem;
            if (person != null)
            {
                MessageBoxResult result = MessageBox.Show("Удалить данные сотрудника: \n" + person.FirstName + person.LastName + " ",
                "Предупреждение", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                if (result == MessageBoxResult.OK)
                {
                    // удаление данных в списке отображения данных
                    teachDPO.Remove(person);
                    Teacher per = new Teacher();
                    per = per.CopyFromTeacherDPO(person);
                    vmTeach.ListTeacher.Remove(per);
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать данные сотрудника для удаления",
                "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

    }
}