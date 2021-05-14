using MidCourseProjectBusiness;
using MidCourseProjectModel;
using MidCourseProjectWPF.Popups;
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

namespace MidCourseProjectWPF
{
    /// <summary>
    /// Interaction logic for AdminDashBoard.xaml
    /// </summary>
    public partial class AdminDashBoard : Window
    {
        DatabaseManager manager = new DatabaseManager();
        public static MainWindow mainWin = new MainWindow();

        Globals g = new Globals();

        private Employer _employer = new Employer();
        private Employee _SelectEmployee = new Employee();

        private List<Employee> _empList = new List<Employee>(); ///FOR LEFT LISTVIEW
        private List<EmployeeClock> _empClockList = new List<EmployeeClock>(); ///FOR RIGHT VIEW

        //Popup Windows
        private ViewDetails viewDetail;

        public AdminDashBoard(Employer employer)
        {
            InitializeComponent();
            titlelabel_instructions.Content = "When Viewing employee details, Adding or Removing please make sure to select the \ncorrect employee. As changes to data are permenant";
            if (employer.FirstName != null && employer.LastName != null)
            {
                _employer = employer;
                greetingLbl.Content = $"{_employer.FirstName} {_employer.LastName}";
                _empList = manager.EmployerRetreiveEmployeeData();
                EmployeeListView.ItemsSource = _empList;
                CheckIsWorkingNotifyer();
                UpdateBtn.IsEnabled = false;
                ViewDetails_Btn.IsEnabled = false;
                RemoveBtn.IsEnabled = false;
            }
            else
            {
                //Display dialoge box to show data
            }
            
        }
        public AdminDashBoard()
        {
            InitializeComponent();
            greetingLbl.Content = "Nothing passed through to display";
        }
        public void CheckIsWorkingNotifyer()
        {
            foreach (var i in _empList)
            {
                if(i.IsWorking == 0)
                {
                    ViewDetailsBtn.Badge = "*";
                    break;
                }
                else
                {
                    ViewDetailsBtn.Badge = null;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            mainWin.Show();
            Hide();
        }

        private void EmployeeListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            if (EmployeeListView.SelectedItem != null)
            {
                UpdateBtn.IsEnabled = true;
                ViewDetails_Btn.IsEnabled = true;
                RemoveBtn.IsEnabled = true;
                Employee currentItem = EmployeeListView.SelectedItem as Employee;
                _SelectEmployee = currentItem;
                var id = currentItem.EmployeeId;
                _empClockList = manager.RetreiveEmployeeClocksData(id);
                HoursListView.ItemsSource = _empClockList;
            }

        }

        private void ViewDetails_Btn_Click(object sender, RoutedEventArgs e)
        {
            viewDetail = new ViewDetails(_SelectEmployee);
            ViewDetails_Btn.IsEnabled = false;
            UpdateBtn.IsEnabled = false;
            RemoveBtn.IsEnabled = false;
            viewDetail.ShowDialog();
            _empList = manager.EmployerRetreiveEmployeeData();
            EmployeeListView.ItemsSource = _empList;
        }
    }
}
