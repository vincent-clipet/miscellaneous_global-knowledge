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
using GradesPrototype.Data;
using GradesPrototype.Services;

namespace GradesPrototype.Views
{
    /// <summary>
    /// Interaction logic for LogonPage.xaml
    /// </summary>
    public partial class LogonPage : UserControl
    {
        public LogonPage()
        {
            InitializeComponent();
        }

        #region Event Members
        public event EventHandler LogonSuccess;
        public event EventHandler LogonFailed;

        // Exercise 3: Task 1a: Define LogonFailed event

        #endregion

        #region Logon Validation

        // Exercise 3: Task 1b: Validate the username and password against the Users collection in the MainWindow window
        private void Logon_Click(object sender, RoutedEventArgs e)
        {
            var teacherQuery = from Teacher t in DataSource.Teachers
                          where t.UserName == username.Text
                          && t.Password == password.Password
                          select t;

            if (teacherQuery.Count() > 0) // Teacher
            {
                Teacher t = teacherQuery.First();
                SessionContext.UserID = t.TeacherID;
                SessionContext.UserRole = Role.Teacher;
                SessionContext.UserName = t.UserName;
                SessionContext.CurrentTeacher = t;

                LogonSuccess?.Invoke(this, null);
            }
            else // Student or Invalid Login
            {
                var studentQuery = from Student s in DataSource.Students
                                   where s.UserName == username.Text
                                   && s.Password == password.Password
                                   select s;

                if (studentQuery.Count() > 0) // Student
                {
                    Student s = studentQuery.First();
                    SessionContext.UserID = s.TeacherID;
                    SessionContext.UserRole = Role.Student;
                    SessionContext.UserName = s.UserName;
                    SessionContext.CurrentStudent = s;

                    LogonSuccess?.Invoke(this, null);
                }
                else // Invalid Login
                {
                    LogonFailed?.Invoke(this, null);
                }
            }
        }
        #endregion
    }
}
