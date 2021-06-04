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
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        DatabaseManager manager = new DatabaseManager(new EmployeeService());
        private static MainWindow _mainWin = new MainWindow();
        private Employee _employee = new Employee();

        Globals g = new Globals();


        private string _message = "_", _caption = "_";
        public RegisterWindow(Employee employee)
        {
            InitializeComponent();
            _employee = employee;
        }
        public RegisterWindow()
        {
            InitializeComponent();
        }


        private void BackToHomePageButton_Click(object sender, RoutedEventArgs e)
        {
            _mainWin.Show();
            Hide();
        }

        private void userNameTxtbx_TextChanged(object sender, TextChangedEventArgs e)
        {
           
        }

        private void firstNameTxtbx_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void lastNameTxtbx_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void addressTxtbx_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void cityTxtbx_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void postCodeTxtbx_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void phoneNumberTxtbx_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void passwordTxtbx_textInput(object sender, TextCompositionEventArgs e)
        {
            
        }

        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            if (verifyID())
            {
                if (verifyOtherDetails())
                {
                    if (verifyPassword())
                    {
                        string errorMessage = "";
                        _employee.IsWorking = 0; /// FALSE = 0 || TRUE = 1
                        _employee.HrRate = 10;
                        _employee.Position = "Awaiting Admin confirmation";
                        if (manager.CreateEmployee(_employee, out errorMessage))
                        {
                            g.MessageNotify(errorMessage, "Registeration successful");
                            _mainWin.Show();//NEEDS CHANGING!!!!!!!!
                            Close();
                        }
                        else
                        {
                            g.MessageNotify(errorMessage, "Registeration Failed");
                        }
                    }
                }
            }
        }

        public bool verifyID()
        {
            bool verResult = false;
            _caption = "Value entered for UserName not acceptable.".ToUpper();
            _message = "Make sure to use a memorable and unique 5 character long username.".ToUpper();
            if (userNameTxtbx.Text.Length == 5)
            {
                _employee.EmployeeId = userNameTxtbx.Text;
                verResult = true;
            }
            else
            {
                g.MessageNotify(_message, _caption);
                verResult = false;
            }
            return verResult;
        }

        public bool verifyPassword()
        {
            bool verResult = false;
            _caption = "Value entered for Password not acceptable.".ToUpper();
            _message = "Make sure to use a memorable 8 character long password.".ToUpper();
            if (passwordTxtbx.Password.Length >= 8 && passwordTxtbx.Password.Length < 12)
            {
                _employee.Password = passwordTxtbx.Password;
                verResult = true;
            }
            else
            {
                g.MessageNotify(_message, _caption);
                verResult = false;
            }
            return verResult;
        }

        public bool verifyOtherDetails()
        {
            bool verResult = false;
            if (firstNameTxtbx.Text.Length > 2 && lastNameTxtbx.Text.Length > 2 && firstNameTxtbx.Text.Length < 20 && lastNameTxtbx.Text.Length < 20)
            {
                _employee.FirstName = firstNameTxtbx.Text;
                _employee.LastName = lastNameTxtbx.Text;
                if(addressTxtbx.Text.Length > 2 && cityTxtbx.Text.Length > 2 && postCodeTxtbx.Text.Length > 4)
                {
                    _employee.Address = addressTxtbx.Text;
                    _employee.City = cityTxtbx.Text;
                    _employee.PostCode = postCodeTxtbx.Text;
                    if(phoneNumberTxtbx.Text.Length == 11)
                    {
                        _employee.PhoneNumber = phoneNumberTxtbx.Text.ToString();
                        verResult = true;
                    }
                    else
                    {
                        _caption = "Value entered for Phone number is not acceptable.".ToUpper();
                        _message = "Make sure that your phone number feild is correct and 11 digits long example: 07493129528 (Do not put +44).".ToUpper();
                        g.MessageNotify(_message, _caption);
                        verResult = false;
                    }
                }
                else
                {
                    _caption = "Value entered for Address fields are not acceptable.".ToUpper();
                    _message = "Make sure that your Address, City and Post code feilds are correct and no shorter then 4 characters.".ToUpper();
                    g.MessageNotify(_message, _caption);
                    verResult = false;
                }
                
            }
            else
            {
                _caption = "Value entered for First and last Name are not acceptable.".ToUpper();
                _message = "Make sure that your first and last name are correct and no shorter than 2 characters.".ToUpper();
                g.MessageNotify(_message, _caption);
                verResult = false;
            }
            return verResult;
        }
    }
}
