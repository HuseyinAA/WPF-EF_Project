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
using MidCourseProjectModel;
using MidCourseProjectBusiness;

namespace MidCourseProjectWPF
{
    /// <summary>
    /// Interaction logic for EmployeeDashboard.xaml
    /// </summary>
    public partial class EmployeeDashboard : Window
    {
        DatabaseManager manager = new DatabaseManager();
        public static MainWindow mainWin = new MainWindow();

        Globals g = new Globals();

        private Employee _employee = new Employee();

        public EmployeeDashboard(Employee employee)
        {
            InitializeComponent();
            _employee = employee;
            greetingLbl.Content = $"{_employee.EmployeeId} - Hello {_employee.FirstName} {_employee.LastName}";
        }
        public EmployeeDashboard()
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
