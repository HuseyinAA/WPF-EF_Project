using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MidCourseProjectWPF
{
    public class Globals
    {
        public void MessageNotify(string message, string caption)
        {
            MessageBox.Show(message.ToUpper(), caption.ToUpper());
        }
    }
}
