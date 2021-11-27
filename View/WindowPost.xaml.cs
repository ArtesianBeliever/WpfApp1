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
    public partial class WindowChair : Window
    {
        PostVM vmPost = new PostVM();
        public WindowChair()
        {
            InitializeComponent();
            lvPost.ItemsSource = vmPost.ListPost;
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            NewPost wnPost = new NewPost
            {
                Title = "Новая Должность",
                Owner = this
            };
            // формирование кода новой должности
            int maxIdQual = vmPost.MaxIdQ() + 1;
            Post qual = new Post
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
                Title = "Редактирование Должности",
                Owner = this
            };
            Post qual = lvPost.SelectedItem as Post;
            if (qual != null)
            {
                Post tempQual = qual.ShallowCopy();
                wnPost.DataContext = tempQual;
                if (wnPost.ShowDialog() == true)
                {
                    // сохранение данных
                    qual.NamePost = tempQual.NamePost;
                    lvPost.ItemsSource = null;
                    lvPost.ItemsSource = vmPost.ListPost;
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать Должность для редактированния",
                "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Post qual = (Post)lvPost.SelectedItem;
            if (qual != null)
            {
                MessageBoxResult result = MessageBox.Show("Удалить данные по Должности: " +
                qual.NamePost, "Предупреждение", MessageBoxButton.OKCancel,
                MessageBoxImage.Warning);
                if (result == MessageBoxResult.OK)
                {
                    vmPost.ListPost.Remove(qual);
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать Должность для удаления",
                "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
