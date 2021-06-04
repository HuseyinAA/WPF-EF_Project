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
using MidCourseProjectBusiness;
using MidCourseProjectModel;

namespace MidCourseProjectWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DatabaseManager manager = new DatabaseManager(new EmployeeService());

        private EmployeeDashboard _EmpDashWin;
        private AdminDashBoard _AdmDashWin;
        private RegisterWindow _regWin = new RegisterWindow();

        Globals g = new Globals();

        private Employee _employee = new Employee();
        private Employer _employer = new Employer();

        private string username, password;
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            _regWin.Show();
            Hide();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void passwordLoginTxt_TextInput(object sender, TextCompositionEventArgs e)
        {

        }

        public bool CheckLoginDetails()
        {
            bool result = false;

            username = usernameLoginTxt.Text;
            password = passwordLoginTxt.Password;

            if(manager.CheckLoginStatus(username, password, out string message, out Employee employee, out Employer employer)) 
            {
                _employee = employee;
                _employer = employer;
                //g.MessageNotify(message, "Login successful");
                result = true;
            }
            else
            {
                g.MessageNotify(message, "Error loging in");
            }
            return result;
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (CheckLoginDetails())
            {
                if(_employee != null)
                {
                    if (_employee.IsWorking == 1)
                    {
                        _EmpDashWin = new EmployeeDashboard(_employee);
                        _EmpDashWin.Show();
                        Hide();
                    }
                    else
                    {
                        g.MessageNotify("Unable to Log in! You will need to wait for your admin to confrim your account", "Awating Admin confirmation");
                    }
                }
                else if(_employer != null)
                {
                    _AdmDashWin = new AdminDashBoard(_employer);
                    _AdmDashWin.Show();
                    Hide();
                }
            }
        }
    }
}
