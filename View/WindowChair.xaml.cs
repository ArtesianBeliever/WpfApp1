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
    public partial class WindowChair : Window
    {

        private ChairVM vmChair;
        private FacultyVM vmFaculty;
        private ObservableCollection<ChairDPO> chDPO;
        private List<Faculty> facs;


        public WindowChair()
        {
            InitializeComponent();
            vmChair = new ChairVM();
            vmFaculty = new FacultyVM();
            facs = vmFaculty.ListFaculty.ToList();
            // Формирование данных для отображения сотрудников с должностями
            // на базе коллекции класса ListPerson<Person>
            chDPO = new ObservableCollection<ChairDPO>();
            foreach (var chair in vmChair.ListChair)
            {
                ChairDPO p = new ChairDPO();
                p = p.CopyFromChair(chair);
                chDPO.Add(p);
            }
            lvChair.ItemsSource = chDPO;
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            NewChair wnEmployee = new NewChair
            {
                Title = "Новая Кафедра",
                Owner = this
            };
            // формирование кода новой кафедры
            int maxIdPerson = vmChair.MaxId() + 1;
            ChairDPO gr = new ChairDPO
            {
                Id = maxIdPerson,
            };
            wnEmployee.DataContext = gr;
            wnEmployee.CbChair.ItemsSource = facs;
            if (wnEmployee.ShowDialog() == true)
            {
                Faculty s = (Faculty)wnEmployee.CbChair.SelectedValue;
                gr.NameFaculty = s.NameFaculty;
                chDPO.Add(gr);
                Chair p = new Chair();
                p = p.CopyFromChairDPO(gr);
                vmChair.ListChair.Add(p);
            }
        }
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            NewChair wnEmployee = new NewChair
            {
                Title = "Редактирование данных",
                Owner = this
            };
            ChairDPO perDPO = (ChairDPO)lvChair.SelectedValue;
            ChairDPO tempPerDPO; // временный класс для редактирования
            if (perDPO != null)
            {
                tempPerDPO = perDPO.ShallowCopy();
                wnEmployee.DataContext = tempPerDPO;
                wnEmployee.CbChair.ItemsSource = facs;
                wnEmployee.CbChair.Text = tempPerDPO.NameFaculty;
                if (wnEmployee.ShowDialog() == true)
                {
                    // перенос данных из временного класса в класс отображения данных
                    Faculty r = (Faculty)wnEmployee.CbChair.SelectedValue;
                    perDPO.NameFaculty = r.NameFaculty;
                    perDPO.NameChair = tempPerDPO.NameChair;
                    perDPO.ShortNameChair = tempPerDPO.ShortNameChair;

                    lvChair.ItemsSource = null;
                    lvChair.ItemsSource = chDPO;
                    // перенос данных из класса отображения данных в класс Person
                    FindChair finder = new FindChair(perDPO.Id);
                    List<Chair> listPerson = vmChair.ListChair.ToList();
                    Chair p = listPerson.Find(new Predicate<Chair>(finder.ChairPredicate));
                    p = p.CopyFromChairDPO(perDPO);
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
            ChairDPO person = (ChairDPO)lvChair.SelectedItem;
            if (person != null)
            {
                MessageBoxResult result = MessageBox.Show("Удалить данные сотрудника: \n" + person.NameChair  + " ",
                "Предупреждение", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                if (result == MessageBoxResult.OK)
                {
                    // удаление данных в списке отображения данных
                    chDPO.Remove(person);
                    Chair per = new Chair();
                    per = per.CopyFromChairDPO(person);
                    vmChair.ListChair.Remove(per);
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