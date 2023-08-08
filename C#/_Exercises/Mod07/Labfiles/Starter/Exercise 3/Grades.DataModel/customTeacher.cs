using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades.DataModel
{
    public partial class Teacher
    {
        private const int MAX_CLASS_SIZE = 8;

        public void EnrollInClass(Student s)
        {
            SchoolGradesDBEntities tmp = new SchoolGradesDBEntities();
            var count = (from Student student in tmp.Students
                       where student.TeacherUserId == UserId
                       select student).Count();
            Console.WriteLine("count = " + count);

            if (count >= MAX_CLASS_SIZE)
                throw new ClassFullException("Class is full ("+MAX_CLASS_SIZE+")");

            if (s.TeacherUserId == null)
                s.TeacherUserId = UserId;
            else
                throw new ArgumentException("Student is already in a class");
        }
    }
}
