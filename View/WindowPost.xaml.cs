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
    public partial class WindowPost : Window
    {
        CurriculumVM vmPost = new CurriculumVM();
        public WindowPost()
        {
            InitializeComponent();
            lvPost.ItemsSource = vmPost.ListPost;
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            NewPost wnPost = new NewPost
            {
                Title = "Новая должность",
                Owner = this
            };
            // формирование кода новой должности
            int maxIdQual = vmPost.MaxIdQ() + 1;
            Curriculum qual = new Curriculum
            {
                Id = maxIdQual
            };
            wnPost.DataContext = qual;
            if (wnPost.ShowDialog() == true)
            {
                vmPost.ListPost.Add(qual);
            }
        }
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            NewPost wnPost = new NewPost
            {
                Title = "Редактирование должности",
                Owner = this
            };
            Curriculum qual = lvPost.SelectedItem as Curriculum;
            if (qual != null)
            {
                Curriculum tempQual = qual.ShallowCopy();
                wnPost.DataContext = tempQual;
                if (wnPost.ShowDialog() == true)
                {
                    // сохранение данных
                    qual.NameCurriculum = tempQual.NameCurriculum;
                    lvPost.ItemsSource = null;
                    lvPost.ItemsSource = vmPost.ListPost;
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать должность для редактированния",
                "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Curriculum qual = (Curriculum)lvPost.SelectedItem;
            if (qual != null)
            {
                MessageBoxResult result = MessageBox.Show("Удалить данные по должности: " +
                qual.NameCurriculum, "Предупреждение", MessageBoxButton.OKCancel,
                MessageBoxImage.Warning);
                if (result == MessageBoxResult.OK)
                {
                    vmPost.ListPost.Remove(qual);
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать должность для удаления",
                "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
