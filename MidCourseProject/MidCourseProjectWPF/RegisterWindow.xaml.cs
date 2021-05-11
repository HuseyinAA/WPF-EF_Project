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

namespace MidCourseProjectWPF
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public static MainWindow mainWin = new MainWindow();
        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void BackToHomePageButton_Click(object sender, RoutedEventArgs e)
        {
            mainWin.Show();
            Hide();
        }
    }
}
