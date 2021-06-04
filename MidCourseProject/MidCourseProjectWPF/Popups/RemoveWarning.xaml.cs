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
    /// Interaction logic for RemoveWarning.xaml
    /// </summary>
    public partial class RemoveWarning : Window
    {
        private DatabaseManager _manager = new DatabaseManager(new EmployeeService());

        private Employee _employee = new Employee();
        private EmployeeClock _employeeClock = new EmployeeClock();

        public RemoveWarning(Employee employee)
        {
            InitializeComponent();
            _employee = employee;
            InstructionLbl.Content = "Once an Employee is removed you will not be able to revert back. \nMake sure to change the status of your Employee first to be able to remove \nyour Employee.";
            MakeSureToChangeIsworkingLbl.Content = "";
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void RemoveBtn_Click(object sender, RoutedEventArgs e)
        {
            _manager.RemoveEmployee(_employee.EmployeeId, _employee.IsWorking, out int close);
            if(close == 1)
            {
                this.Close();
            }
            else
            {
                MakeSureToChangeIsworkingLbl.Content = "MAKE SURE TO CHANGE THE SELECTED EMPLOYEES STATUS!";
            }
        }
    }
}
