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
    /// Логика взаимодействия для WindowForm.xaml
    /// </summary>
    public partial class WindowForm : Window
    {
        FormEducationVM vmForm = new FormEducationVM();
        public WindowForm()
        {
            InitializeComponent();
            
            lvForm.ItemsSource = vmForm.ListFormEducation;
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            NewForm wnForm = new NewForm
            {
                Title = "Новая Форма",
                Owner = this
            };
            // формирование кода новой формы
            int maxIdForm = vmForm.MaxIdF() + 1;
            FormEducation form = new FormEducation
            {
                Id = maxIdForm
            };
            wnForm.DataContext = form;
            if (wnForm.ShowDialog() == true)
            {
                vmForm.ListFormEducation.Add(form);
            }
        }
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            NewForm wnForm = new NewForm
            {
                Title = "Редактирование Формы",
                Owner = this
            };
            FormEducation form = lvForm.SelectedItem as FormEducation;
            if (form != null)
            {
                FormEducation tempForm = form.ShallowCopy();
                wnForm.DataContext = tempForm;
                if (wnForm.ShowDialog() == true)
                {
                    // сохранение данных
                    form.NameForm = tempForm.NameForm;
                    lvForm.ItemsSource = null;
                    lvForm.ItemsSource = vmForm.ListFormEducation;
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
            FormEducation form = (FormEducation)lvForm.SelectedItem;
            if (form != null)
            {
                MessageBoxResult result = MessageBox.Show("Удалить данные по форме: " +
                form.NameForm, "Предупреждение", MessageBoxButton.OKCancel,
                MessageBoxImage.Warning);
                if (result == MessageBoxResult.OK)
                {
                    vmForm.ListFormEducation.Remove(form);
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
