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

namespace MidCourseProjectWPF.Popups
{
    /// <summary>
    /// Interaction logic for ViewEmployeeDetails.xaml
    /// </summary>
    public partial class ViewEmployeeDetails : Window
    {
        private DatabaseManager _manager = new DatabaseManager(new EmployeeService());

        Globals g = new Globals();

        private Employee _employee = new Employee();

        private string _mainPassword = "";
        private bool _PasswordChanged = false;


        public ViewEmployeeDetails(Employee employee)
        {
            InitializeComponent();
            _employee = employee;
            InitialiseUI();

        }

        public void InitialiseUI()
        {
            //Assigning data to the fields
            FirstNameTextBox.Text = _employee.FirstName;
            LastNameTextBox.Text = _employee.LastName;
            AddressTextBox.Text = _employee.Address;
            CityTextBox.Text = _employee.City;
            PostalCodeTextBox.Text = _employee.PostCode;
            PhoneTextBox.Text = _employee.PhoneNumber;
            //Password needs to be set if user wants to change it otherwise should not be given access at all or viewed
            UsernameLbl.Content = $"Username: {_employee.EmployeeId}";
            var AccountStatus = _employee.IsWorking == 1 ? "Active" : "Deactivated";
            AccountStatusLbl.Content = $"Account Status: {AccountStatus}";
            PositionLbl.Content = $"Position: {_employee.Position}";
            string sFormat = string.Format("£{0:N2}", _employee.HrRate);
            HourlyRateLbl.Content = $"Hourly Rate: {sFormat}";

            //Disabling access for anymodification to textboxes
            FirstNameTextBox.IsEnabled = false;
            LastNameTextBox.IsEnabled = false;
            AddressTextBox.IsEnabled = false;
            CityTextBox.IsEnabled = false;
            PostalCodeTextBox.IsEnabled = false;
            PhoneTextBox.IsEnabled = false;
            PasswordBox.IsEnabled = false;
            SaveBtn.IsEnabled = false;
        }

        public void IsEditable(bool? isEditable)
        {
            if (isEditable == true)
            {
                //Disabling access for anymodification to textboxes
                FirstNameTextBox.IsEnabled = true;
                LastNameTextBox.IsEnabled = true;
                AddressTextBox.IsEnabled = true;
                CityTextBox.IsEnabled = true;
                PostalCodeTextBox.IsEnabled = true;
                PhoneTextBox.IsEnabled = true;
                PasswordBox.IsEnabled = true;
                SaveBtn.IsEnabled = true;
            }
            else
            {
                //Disabling access for anymodification to textboxes
                FirstNameTextBox.IsEnabled = false;
                LastNameTextBox.IsEnabled = false;
                AddressTextBox.IsEnabled = false;
                CityTextBox.IsEnabled = false;
                PostalCodeTextBox.IsEnabled = false;
                PhoneTextBox.IsEnabled = false;
                PasswordBox.IsEnabled = false;
                SaveBtn.IsEnabled = false;
            }
        }

        public bool InputtedDataCheck()
        {
            bool passCheck = false, nameCheck = false, addressCheck = false, phoneCheck = false;
            bool fieldsGood = false;
            if(PasswordBox.Password != "") // if not empty
            {
                if (PasswordBox.Password.Length >= 8 && PasswordBox.Password.Length < 12)
                {
                    _employee.Password = PasswordBox.Password;
                    passCheck = true;
                    if (FirstNameTextBox.Text.Length > 2 && LastNameTextBox.Text.Length > 2 && FirstNameTextBox.Text.Length < 20 && LastNameTextBox.Text.Length < 20)
                    {
                        _employee.FirstName = FirstNameTextBox.Text;
                        _employee.LastName = LastNameTextBox.Text;
                        nameCheck = true;
                        if (AddressTextBox.Text.Length > 2 && CityTextBox.Text.Length > 2 && PostalCodeTextBox.Text.Length > 4)
                        {
                            _employee.Address = AddressTextBox.Text;
                            _employee.City = CityTextBox.Text;
                            _employee.PostCode = PostalCodeTextBox.Text;
                            addressCheck = true;
                            if (PhoneTextBox.Text.Length == 11)
                            {
                                _employee.PhoneNumber = PhoneTextBox.Text.ToString();
                                phoneCheck = true;
                            }
                        }
                    }
                }
                if(passCheck == true && nameCheck == true && addressCheck == true && phoneCheck == true)
                {
                    fieldsGood = true;
                    _PasswordChanged = true;
                }
            }
            else
            {
                if (FirstNameTextBox.Text.Length > 2 && LastNameTextBox.Text.Length > 2 && FirstNameTextBox.Text.Length < 20 && LastNameTextBox.Text.Length < 20)
                {
                    _employee.FirstName = FirstNameTextBox.Text;
                    _employee.LastName = LastNameTextBox.Text;
                    nameCheck = true;
                    if (AddressTextBox.Text.Length > 2 && CityTextBox.Text.Length > 2 && PostalCodeTextBox.Text.Length > 4)
                    {
                        _employee.Address = AddressTextBox.Text;
                        _employee.City = CityTextBox.Text;
                        _employee.PostCode = PostalCodeTextBox.Text;
                        addressCheck = true;
                        if (PhoneTextBox.Text.Length == 11)
                        {
                            _employee.PhoneNumber = PhoneTextBox.Text.ToString();
                            phoneCheck = true;
                        }
                    }
                }
                if (nameCheck == true && addressCheck == true && phoneCheck == true)
                {
                    fieldsGood = true;
                }
            }
            return fieldsGood;
        }


        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            //needs to check if password has been changed ---> make sure to apply password validations
            //Needs to check if any changes have been made
            if (InputtedDataCheck())
            {
                if (_PasswordChanged)
                {
                    _manager.UpdateEmployeePassword(_employee.EmployeeId, _employee);
                }
                else
                {
                    _manager.UpdateEmployee(_employee.EmployeeId, _employee);
                }
            }
            this.Close();
        }

        private void Cancel_Btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void EditableCheckBox_Click(object sender, RoutedEventArgs e)
        {
            IsEditable(EditableCheckBox.IsChecked);
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            _mainPassword = PasswordBox.Password;
        }
    }
}
