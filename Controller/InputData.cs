using StudentManagement.Constants;
using StudentManagement.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Controller
{
    public class InputData
    {
        private List<Student> studentStorageList;

        public InputData(List<Student> studentList)
        {
            studentStorageList = studentList;
        }

        public int GetInt(string msg, int min, int max)
        {
            int value;
            do
            {
                Console.Write($"{msg} ({min} - {max}): ");
                if (!int.TryParse(Console.ReadLine(), out value) || !Validate.IsIntInRange(value, min, max))
                {
                    Console.WriteLine($"Error: Must be an integer between {min} and {max}");
                }
            } while (!Validate.IsIntInRange(value, min, max));
            return value;
        }

        public double GetDouble(string msg, double min, double max)
        {
            double value;
            do
            {
                Console.Write($"{msg} ({min} - {max}): ");
                if (!double.TryParse(Console.ReadLine(), out value) || !Validate.IsDoubleInRange(value, min, max))
                {
                    Console.WriteLine($"Error: Must be a number between {min} and {max}");
                }
            } while (!Validate.IsDoubleInRange(value, min, max));
            return value;
        }


        public string GetString(string msg, int minLength, int maxLength)
        {
            string input;
            do
            {
                Console.Write($"{msg}: ");
                input = Console.ReadLine() ?? string.Empty;
                if (!Validate.IsStringValid(input, minLength, maxLength))
                {
                    Console.WriteLine($"Error: Input must be between {minLength} and {maxLength} characters and not empty");
                }
            } while (!Validate.IsStringValid(input, minLength, maxLength));
            return input;
        }

        public DateTime GetDateOfBirth(string msg)
        {
            DateTime date;
            do
            {
                Console.Write($"{msg} (dd/MM/yyyy): ");
                if (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date) || !Validate.IsDateOfBirthValid(date))
                {
                    Console.WriteLine($"Error: Invalid date format or year must be from {AppConstants.MinBirthYear} to current year.");
                }
            } while (!Validate.IsDateOfBirthValid(date));
            return date;
        }

        public string GetStudentId(string msg)
        {
            string studentId;
            do
            {
                Console.Write($"{msg} ({AppConstants.StudentIdLength} characters): ");
                studentId = Console.ReadLine() ?? string.Empty;
                if (!Validate.IsStudentIdValid(studentId, studentStorageList))
                {
                    Console.WriteLine($"Error: Student ID must be {AppConstants.StudentIdLength} characters and unique.");
                }
            } while (!Validate.IsStudentIdValid(studentId, studentStorageList));
            return studentId;
        }
    }
}