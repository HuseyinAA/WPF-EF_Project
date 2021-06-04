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
    /// Interaction logic for ViewAdminDetails.xaml
    /// </summary>
    public partial class ViewAdminDetails : Window
    {

        private DatabaseManager _manager = new DatabaseManager(new EmployeeService());

        Globals g = new Globals();

        private Employer _employer = new Employer();

        private string _mainPassword = "";
        private bool _PasswordChanged = false;

        public ViewAdminDetails(Employer employer)
        {
            InitializeComponent();
            _employer = employer;
            InitialiseUI();
        }

        public void InitialiseUI()
        {
            //Assigning data to the fields
            FirstNameTextBox.Text = _employer.FirstName;
            LastNameTextBox.Text = _employer.LastName;
            //Password needs to be set if user wants to change it otherwise should not be given access at all or viewed
            UsernameLbl.Content = $"Username: {_employer.EmployerId}";

            //Disabling access for anymodification to textboxes
            FirstNameTextBox.IsEnabled = false;
            LastNameTextBox.IsEnabled = false;
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
                PasswordBox.IsEnabled = true;
                SaveBtn.IsEnabled = true;
            }
            else
            {
                //Disabling access for any modification to textboxes
                FirstNameTextBox.IsEnabled = false;
                LastNameTextBox.IsEnabled = false;
                PasswordBox.IsEnabled = false;
                SaveBtn.IsEnabled = false;
            }
        }

        public bool InputtedDataCheck()
        {
            bool passCheck = false, nameCheck = false;
            bool fieldsGood = false;
            if (PasswordBox.Password != "") // if not empty
            {
                if (PasswordBox.Password.Length >= 8 && PasswordBox.Password.Length < 12)
                {
                    _employer.Password = PasswordBox.Password;
                    passCheck = true;
                    if (FirstNameTextBox.Text.Length > 2 && LastNameTextBox.Text.Length > 2 && FirstNameTextBox.Text.Length < 20 && LastNameTextBox.Text.Length < 20)
                    {
                        _employer.FirstName = FirstNameTextBox.Text;
                        _employer.LastName = LastNameTextBox.Text;
                        nameCheck = true;
                    }
                }
                if (passCheck == true && nameCheck == true)
                {
                    fieldsGood = true;
                    _PasswordChanged = true;
                }
            }
            else
            {
                if (FirstNameTextBox.Text.Length > 2 && LastNameTextBox.Text.Length > 2 && FirstNameTextBox.Text.Length < 20 && LastNameTextBox.Text.Length < 20)
                {
                    _employer.FirstName = FirstNameTextBox.Text;
                    _employer.LastName = LastNameTextBox.Text;
                    fieldsGood = true;
                }
            }
            return fieldsGood;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (InputtedDataCheck())
            {
                if (_PasswordChanged)
                {
                    _manager.UpdateAdminPassword(_employer.EmployerId, _employer);
                }
                else
                {
                    _manager.UpdateAdmin(_employer.EmployerId, _employer);
                }
            }
            this.Close();
        }

        private void Cancel_Btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            _mainPassword = PasswordBox.Password;
        }

        private void EditableCheckBox_Click(object sender, RoutedEventArgs e)
        {
            IsEditable(EditableCheckBox.IsChecked);
        }
    }
}
