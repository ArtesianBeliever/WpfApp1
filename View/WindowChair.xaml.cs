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
    /// Логика взаимодействия для WindowSpec.xaml
    /// </summary>
    public partial class WindowSpec : Window
    {
        public WindowSpec()
        {
            InitializeComponent();
            ChairVM vmChair = new ChairVM();
            FacultyVM vmFaculty = new FacultyVM();
            List<Faculty> facu = new List<Faculty>();
 //           
            foreach (Faculty f in vmFaculty.ListFaculty)
            {
                facu.Add(f);
            }
            ObservableCollection<ChairDPO> faculties = new ObservableCollection<ChairDPO>();
            FindFaculty finder3;
            foreach (var s in vmChair.ListChair)
            {
                finder3 = new FindFaculty(s.IdFaculty);
                Faculty fac = facu.Find(new Predicate<Faculty>(finder3.FacultyPredicate));
                faculties.Add(new ChairDPO
                {
                    Id = s.Id,
                    NameFaculty = fac.NameFaculty,
                    NameChair = s.NameChair,
                    ShortNameChair = s.ShortNameChair
                });
            }
            lvSpeciality.ItemsSource = faculties;
        }
    }
}
