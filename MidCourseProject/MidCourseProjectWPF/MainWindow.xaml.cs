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
        DatabaseManager manager = new DatabaseManager();

        private EmployeeDashboard _EmpDashWin;
        private RegisterWindow _regWin = new RegisterWindow();

        Globals g = new Globals();

        private Employee _employee = new Employee();

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

            if(manager.CheckLoginStatus(username, password, out string message, out Employee emp)) 
            {
                _employee = emp;
                g.MessageNotify(message, "Login successful");
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
                _EmpDashWin = new EmployeeDashboard(_employee);
                _EmpDashWin.Show();
                Hide();
            }
            
        }
    }
}
