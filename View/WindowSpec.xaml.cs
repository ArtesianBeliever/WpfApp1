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
    /// Логика взаимодействия для WindowSpec.xaml
    /// </summary>
    public partial class WindowSpec : Window
    {
        SpecialityVM vmSpec = new SpecialityVM();
        public WindowSpec()
        {
            InitializeComponent();
            lvSpeciality.ItemsSource = vmSpec.ListSpeciality;
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            NewSpec wnSpec = new NewSpec
                {
            Title = "Новая должность",
            Owner = this
                };
            int maxIdSpec = vmSpec.MaxIdS() + 1;
            Speciality special = new Speciality
            {
                Id = maxIdSpec
            };
            wnSpec.DataContext = special;
            if (wnSpec.ShowDialog() == true)
            {
                vmSpec.ListSpeciality.Add(special);
            }
        }
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            NewSpec wnRole = new NewSpec
            {
                Title = "Редактирование должности",
                Owner = this
            };
            Speciality spec = lvSpeciality.SelectedItem as Speciality;
            if (spec != null)
            {
                Speciality tempSpec = spec.ShallowCopy();
                wnRole.DataContext = tempSpec;
                if (wnRole.ShowDialog() == true)
                {
                    // сохранение данных
                    spec.NameSpeciality = tempSpec.NameSpeciality;
                    spec.Profile = tempSpec.Profile;
                    lvSpeciality.ItemsSource = null;
                    lvSpeciality.ItemsSource = vmSpec.ListSpeciality;
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
            Speciality spec = (Speciality)lvSpeciality.SelectedItem;
            if (spec != null)
            {
                MessageBoxResult result = MessageBox.Show("Удалить данные по должности: " +
                spec.NameSpeciality, "Предупреждение", MessageBoxButton.OKCancel,
                MessageBoxImage.Warning);
                if (result == MessageBoxResult.OK)
                {
                    vmSpec.ListSpeciality.Remove(spec);
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
