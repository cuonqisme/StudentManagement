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
        private List<Student> _studentList;

        public InputData(List<Student> studentList)
        {
            _studentList = studentList;
        }

        public int GetInt(string prompt, int min, int max)
        {
            int value;
            do
            {
                Console.Write($"{prompt} ({min} - {max}): ");
                if (!int.TryParse(Console.ReadLine(), out value) || !Validate.IsIntInRange(value, min, max))
                {
                    Console.WriteLine($"Error: Must be an integer between {min} and {max}.");
                }
            } while (!Validate.IsIntInRange(value, min, max));
            return value;
        }

        public double GetDouble(string prompt, double min, double max)
        {
            double value;
            do
            {
                Console.Write($"{prompt} ({min} - {max}): ");
                if (!double.TryParse(Console.ReadLine(), out value) || !Validate.IsDoubleInRange(value, min, max))
                {
                    Console.WriteLine($"Error: Must be a number between {min} and {max}.");
                }
            } while (!Validate.IsDoubleInRange(value, min, max));
            return value;
        }


        public string GetString(string prompt, int minLength, int maxLength)
        {
            string input;
            do
            {
                Console.Write($"{prompt}: ");
                input = Console.ReadLine() ?? string.Empty;
                if (!Validate.IsStringValid(input, minLength, maxLength))
                {
                    Console.WriteLine($"Error: Input must be between {minLength} and {maxLength} characters and not empty.");
                }
            } while (!Validate.IsStringValid(input, minLength, maxLength));
            return input;
        }
    }
}