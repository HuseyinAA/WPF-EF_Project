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
using MidCourseProjectWPF.Popups;

namespace MidCourseProjectWPF
{
    /// <summary>
    /// Interaction logic for EmployeeDashboard.xaml
    /// </summary>
    public partial class EmployeeDashboard : Window
    {
        private DatabaseManager _manager = new DatabaseManager();
        private static MainWindow _mainWin = new MainWindow();
        private ViewEmployeeDetails _ViewDetails;

        Globals g = new Globals();

        private Employee _employee = new Employee();
        private EmployeeClock _employeeClocks = new EmployeeClock();

        List<EmployeeClock> empList = new List<EmployeeClock>();

        private DateTime _selectedDate;
        private DateTime? _selectedClockIn;
        private DateTime? _selectedClockOut;
        private int _selectedEmployeeClockID;

        public EmployeeDashboard(Employee employee)
        {
            InitializeComponent();
            _employee = employee;
            greetingLbl.Content = $"{_employee.FirstName} {_employee.LastName}";
            empList = _manager.RetreiveEmployeeClocksData(_employee.EmployeeId);
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
            _mainWin.Show();
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

            var difference = cin - cout;
            
            var totalMins = Math.Abs(difference.Minutes);
            var totalHours = Math.Abs(difference.Hours);

            var totalhourlyPay = (totalHours * _employee.HrRate);
            var totalMinDiv = totalMins / 60.0;
            var totalMinPay = (Decimal)totalMinDiv * _employee.HrRate;
            var totalPay = totalhourlyPay + totalMinPay;
            _employeeClocks.TotalPay = totalPay;
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            //Check if values have been entered ie validations,
            //  date not less than today, clock in not greater than clock out visversa
            //Add them to the database

            if (BasicCheck())
            {
                if (_manager.CreateEmployeeClock(_employeeClocks, out string message))
                {
                    g.MessageNotify(message, "Saved!");
                    empList = _manager.RetreiveEmployeeClocksData(_employee.EmployeeId);
                    HoursListView.ItemsSource = empList;
                }
                else
                {
                    g.MessageNotify(message, "Failed");
                }
            }
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            if(HoursListView.SelectedItem != null)
            {
                if (BasicCheck())
                {
                    //Update data
                    if (_manager.UpdateEmployeeClocks(_selectedEmployeeClockID, _employeeClocks, out string message))
                    {
                        g.MessageNotify(message, "Updated!");
                        empList = _manager.RetreiveEmployeeClocksData(_employee.EmployeeId);
                        HoursListView.ItemsSource = empList;
                    }
                    else
                    {
                        g.MessageNotify(message, "Error Updating");
                    }
                }
            }
            else
            {
                g.MessageNotify("Make sure to select a shift to edit!", "No Shifts selected");
            }
        }

        private void HoursListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(HoursListView.SelectedItem != null)
            {
                EmployeeClock currentItem = HoursListView.SelectedItem as EmployeeClock;
                _selectedEmployeeClockID = currentItem.EmployeeClockId;
                _selectedDate = currentItem.ClockDate;
                _selectedClockIn = currentItem.ClockIn;
                DatePicker.SelectedDate = _selectedDate;
                ClockInPicker.SelectedTime = _selectedClockIn;
                if (currentItem.ClockOut != null)
                {
                    _selectedClockOut = currentItem.ClockOut;
                    ClockOutPicker.SelectedTime = _selectedClockOut;
                }
            }
        }

        private void greetingLbl_Click(object sender, RoutedEventArgs e)
        {
            _ViewDetails = new ViewEmployeeDetails(_employee);
            _ViewDetails.ShowDialog();
            greetingLbl.Content = $"{_employee.FirstName} {_employee.LastName}";
        }
    }
}
