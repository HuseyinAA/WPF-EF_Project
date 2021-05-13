using MidCourseProjectBusiness;
using MidCourseProjectModel;
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
    /// Interaction logic for AdminDashBoard.xaml
    /// </summary>
    public partial class AdminDashBoard : Window
    {
        DatabaseManager manager = new DatabaseManager();
        public static MainWindow mainWin = new MainWindow();

        Globals g = new Globals();

        private Employer _employer = new Employer();

        public AdminDashBoard(Employer employer)
        {
            InitializeComponent();
            _employer = employer;
            greetingLbl.Content = $"{_employer.EmployerId} - Hello {_employer.FirstName} {_employer.LastName}";
        }
        public AdminDashBoard()
        {
            InitializeComponent();
            greetingLbl.Content = "Nothing passed through to display";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            mainWin.Show();
            Hide();
        }
    }
}
