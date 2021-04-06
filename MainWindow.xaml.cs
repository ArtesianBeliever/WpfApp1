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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.View;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static int IdSpec { get; set; }
        public static int IdQual { get; set; }
        public static int IdForm { get; set; }
        public static int IdGroup { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            
        }
        private void Group_OnClick(object sender, RoutedEventArgs e)
        {
            WindowGroup wGroup = new WindowGroup();
            wGroup.Show();
        }
        private void Form_OnClick(object sender, RoutedEventArgs e)
        {
            WindowForm wForm = new WindowForm();
            wForm.Show();
        }
        private void Spec_OnClick(object sender, RoutedEventArgs e)
        {
            WindowSpec wSpec = new WindowSpec();
            wSpec.Show();
        }
        private void Qual_OnClick(object sender, RoutedEventArgs e)
        {
            WindowQual wQual = new WindowQual();
            wQual.Show();
        }
    }
}
