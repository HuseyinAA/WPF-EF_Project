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
        private EmployeeClock _employeeClocks = new EmployeeClock();

        List<EmployeeClock> empList = new List<EmployeeClock>();
        

        public EmployeeDashboard(Employee employee)
        {
            InitializeComponent();
            _employee = employee;
            greetingLbl.Content = $"{_employee.FirstName} {_employee.LastName}";
            empList = manager.EmployerWithEmployerClockToRetreiveData(_employee.EmployeeId);
            HoursListView.ItemsSource = empList;
            titlelabel_instructions.Content = "Here you can either Add new clocking times \nor update them.";
            //HoursListView.UpdateLayout();
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

        public bool BasicCheck()
        {
            bool checks = false;
            var date = DatePicker.SelectedDate;
            var clockin = ClockInPicker.SelectedTime;
            var clockout = ClockOutPicker.SelectedTime;

            if(date != null && clockin != null)
            {
                checks = true;
                _employeeClocks.ClockDate = date.Value;
                _employeeClocks.ClockIn = clockin.Value;
                _employeeClocks.EmployeeId = _employee.EmployeeId;
                //_employeeClocks.Employee = _employee;
                CalculateTotalPay();
                if (clockout != null)
                {
                    _employeeClocks.ClockOut = clockout.Value;
                }
            }
            return checks;
        }

        public void CalculateTotalPay()
        {
            DateTime cin = ClockInPicker.SelectedTime.Value;
            DateTime cout = ClockOutPicker.SelectedTime.Value;

            var difference = (cin - cout);
            var totalHours = difference.Hours;

            _employeeClocks.TotalPay = (totalHours * _employee.HrRate);
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            //Check if values have been entered ie validations,
            //  date not less than today, clock in not greater than clock out visversa
            //Add them to the database

            if (BasicCheck())
            {
                if (manager.CreateCustomerClock(_employeeClocks, out string message))
                {
                    g.MessageNotify(message, "Saved!");
                    empList = manager.EmployerWithEmployerClockToRetreiveData(_employee.EmployeeId);
                    HoursListView.ItemsSource = empList;
                }
                else
                {
                    g.MessageNotify(message, "Failed");
                }
            }
        }
    }
}
