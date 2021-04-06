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
    public partial class WindowQual : Window
    {
        QualificationVM vmQual = new QualificationVM();
        public WindowQual()
        {
            InitializeComponent();
            lvQual.ItemsSource = vmQual.ListQualification;
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            NewQual wnQual = new NewQual
 {
 Title = "Новая Квалификация",
 Owner = this
 };
            // формирование кода новой должности
            int maxIdQual = vmQual.MaxIdQ() + 1;
            Qualification qual = new Qualification
            {
                Id = maxIdQual
            };
            wnQual.DataContext = qual;
            if (wnQual.ShowDialog() == true)
            {
                vmQual.ListQualification.Add(qual);
            }
        }
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            NewQual wnQual = new NewQual
            {
                Title = "Редактирование Квалификации",
                Owner = this
            };
            Qualification qual = lvQual.SelectedItem as Qualification;
            if (qual != null)
            {
                Qualification tempQual = qual.ShallowCopy();
                wnQual.DataContext = tempQual;
                if (wnQual.ShowDialog() == true)
                {
                    // сохранение данных
                    qual.NameQualification = tempQual.NameQualification;
                    lvQual.ItemsSource = null;
                    lvQual.ItemsSource = vmQual.ListQualification;
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать квалификацию для редактированния",
                "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Qualification qual = (Qualification)lvQual.SelectedItem;
            if (qual != null)
            {
                MessageBoxResult result = MessageBox.Show("Удалить данные по квалификации: " +
                qual.NameQualification, "Предупреждение", MessageBoxButton.OKCancel,
                MessageBoxImage.Warning);
                if (result == MessageBoxResult.OK)
                {
                    vmQual.ListQualification.Remove(qual);
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать квалификацию для удаления",
                "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
