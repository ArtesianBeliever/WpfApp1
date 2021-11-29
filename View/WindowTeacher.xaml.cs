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
        public WindowGroup()
        {
            InitializeComponent();
            TeacherVM vmTeacher = new TeacherVM();
            ChairVM vmChair = new ChairVM();
            PostVM vmPost = new PostVM();
            List<Chair> chairs = new List<Chair>();
            List<Post> posts = new List<Post>();
            foreach (Chair s in vmChair.ListChair)
            {
                chairs.Add(s);
            }
            foreach (Post q in vmPost.ListPost)
            {
                posts.Add(q);
            }
           
            ObservableCollection<TeacherDPO> groups = new ObservableCollection<TeacherDPO>();
            FindChair finder1;
            FindPost finder2;
            foreach (var p in vmTeacher.ListTeacher)
            {
                finder1 = new FindChair(p.IdChair);
                Chair cha = chairs.Find(new Predicate<Chair>(finder1.ChairPredicate));
                finder2 = new FindPost(p.IdPost);
                Post pos = posts.Find(new Predicate<Post>(finder2.PostPredicate));
                groups.Add(new TeacherDPO
                {
                    Id = p.Id,
                    NameChair = cha.NameChair,
                    NamePost = pos.NamePost,
                    FirstName = p.FirstName,
                    SecondName = p.SecondName,
                    LastName = p.LastName,
                    Phone = p.Phone,
                    EMail = p.EMail
                });
            }
            lvGroup.ItemsSource = groups;

        }
    }
}
