using StudentManagement.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Model
{
    public static class Validate
    {
        public static bool IsStringValid(string? input, int minLength, int maxLength)
        {
            return !string.IsNullOrWhiteSpace(input) && input.Length >= minLength && input.Length <= maxLength;
        }

        public static bool IsDateOfBirthValid(DateTime date)
        {
            return date.Year >= AppConstants.MinBirthYear && date <= DateTime.Now;
        }

        public static bool IsDoubleInRange(double value, double min, double max)
        {
            return value >= min && value <= max;
        }

        public static bool IsIntInRange(int value, int min, int max)
        {
            return value >= min && value <= max;
        }

        public static bool IsStudentIdValid(string studentId, List<Student> students)
        {
            if (string.IsNullOrWhiteSpace(studentId) || studentId.Length != AppConstants.StudentIdLength)
            {
                return false;
            }
            // check uniqueness
            return !students.Any(s => studentId.Equals(s.StudentId, StringComparison.OrdinalIgnoreCase));
        }
    }
}
