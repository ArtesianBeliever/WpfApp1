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

namespace WpfApp1.View
{
    /// <summary>
    /// Логика взаимодействия для WindowQual.xaml
    /// </summary>
    public partial class WindowFaculty : Window
    {
        FacultyVM vmFaculty = new FacultyVM();
        public WindowFaculty()
        {
            InitializeComponent();
            
            lvFaculty.ItemsSource = vmFaculty.ListFaculty;
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            NewFaculty wnForm = new NewFaculty
            {
                Title = "Новая Форма",
                Owner = this
            };
            // формирование кода новой формы
            int maxIdFaculty = vmFaculty.MaxIdF() + 1;
            Faculty form = new Faculty
            {
                Id = maxIdFaculty
            };
            wnForm.DataContext = form;
            if (wnForm.ShowDialog() == true)
            {
                vmFaculty.ListFaculty.Add(form);
            }
        }
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            NewFaculty wnForm = new NewFaculty
            {
                Title = "Редактирование Формы",
                Owner = this
            };
            Faculty form = lvFaculty.SelectedItem as Faculty;
            if (form != null)
            {
                Faculty tempForm = form.ShallowCopy();
                wnForm.DataContext = tempForm;
                if (wnForm.ShowDialog() == true)
                {
                    // сохранение данных
                    form.NameFaculty = tempForm.NameFaculty;
                    form.ShortNameFaculty = tempForm.ShortNameFaculty;
                    lvFaculty.ItemsSource = null;
                    lvFaculty.ItemsSource = vmFaculty.ListFaculty;
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать Форму для редактированния",
                "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Faculty form = (Faculty)lvFaculty.SelectedItem;
            if (form != null)
            {
                MessageBoxResult result = MessageBox.Show("Удалить данные по форме: " +
                form.NameFaculty, "Предупреждение", MessageBoxButton.OKCancel,
                MessageBoxImage.Warning);
                if (result == MessageBoxResult.OK)
                {
                    vmFaculty.ListFaculty.Remove(form);
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать форму для удаления",
                "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
