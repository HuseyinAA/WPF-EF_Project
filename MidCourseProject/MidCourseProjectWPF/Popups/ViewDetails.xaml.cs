using MidCourseProjectModel;
using MidCourseProjectBusiness;
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
using System.IO;

namespace MidCourseProjectWPF.Popups
{
    /// <summary>
    /// Interaction logic for ViewDetails.xaml
    /// </summary>
    public partial class ViewDetails : Window
    {

        private Employee _employee = new Employee();
        DatabaseManager manager = new DatabaseManager(new EmployeeService());

        string positionTxtFileLocation = "C:/Users/Mrhos/Desktop/Sparta_Global/Projects/wpf-ef_Project/WPF-EF_Project/MidCourseProject/MidCourseProjectWPF/Resources/Positions.txt";

        public ViewDetails(Employee employee)
        {
            InitializeComponent();
            _employee = employee;
            EmployeeNameLbl.Content = $"Name: {employee.FirstName} {employee.LastName}";
            EmployeeAddressLbl.Content = $"Address: {employee.Address} \n                  {employee.City} \n                  {employee.PostCode}";
            EmployeePhoneLbl.Content = $"Phone: {employee.PhoneNumber}";
            EmployeeWorkStatusCheckBox.IsChecked = IsChecked();
            EmployeePositionsCombobox.ItemsSource = (File.ReadAllLines(positionTxtFileLocation));
            HrlyPayTextBox.Text = $"{employee.HrRate}";
        }

        public bool IsChecked()
        {
            bool IsChecked = false;
            if(_employee.IsWorking == 1)
            {
                IsChecked = true;
            }
            else
            {
                IsChecked = false;
            }
            return IsChecked;
        }
        public int IsChecked(bool? check)
        {
            if (check == true)
            {
                return 1;
            }
            else if (check == null)
            {
                return 0;
            }
            else
            {
                return 0;
            }
        }


        private void Cancel_Btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if(_employee != null)
            {
                if (decimal.TryParse(HrlyPayTextBox.Text, out decimal result))
                {
                    _employee.HrRate = result;
                    _employee.IsWorking = IsChecked(EmployeeWorkStatusCheckBox.IsChecked);
                    _employee.Position = EmployeePositionsCombobox.Text;

                    if (manager.AdminUpdatingEmployee(_employee.EmployeeId, _employee))
                    {
                        this.Close();
                    }
                }
            }
        }
    }
}
