using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Grades.DataModel
{
    public partial class Grade
    {
        public bool ValidateAssessmentDate(DateTime dt)
        {
            if (dt.CompareTo(DateTime.Now) > 0)
                throw new ArgumentOutOfRangeException("Date can't be in the future");
            else
                return true;
        }

        public Boolean ValidateAssessmentGrade(String s)
        {
            Match matchGrade = Regex.Match(s, @"^[A-E][+-]?$");
            if (matchGrade.Success)
                return true;
            else
                throw new ArgumentOutOfRangeException("Grade is not in a valid format");
        }
    }
}
