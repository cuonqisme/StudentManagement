using StudentManagement.Constants;
using StudentManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace StudentManagement.Controller
{
    public class StudentManager
    {
        private List<Student> students;
        private InputData inputDataFromUser;

        public StudentManager()
        {
            students = new List<Student>();
            inputDataFromUser = new InputData(students);
        }

        public void DemoData()
        {
            try
            {
                //students.Clear();
                students = new List<Student>()
            {
            new Student("Tran Tuan Anh", new DateTime(2003, 10, 15), "Ha Noi", 175, 65, "HE170123", "FPTU", 2021, 8.5),
            new Student("Nguyen Thi Linh", new DateTime(2004, 02, 20), "Hai Phong", 162, 50, "SE182456", "HUST", 2022, 7.8),
            new Student("Le Minh Duc", new DateTime(2003, 05, 30), "Da Nang", 180, 72, "HE173344", "VNU", 2021, 9.1),
            new Student("Pham Van Bao", new DateTime(2002, 08, 11), "Nghe An", 168, 60, "SS160789", "NEU", 2020, 6.9),
            new Student("Hoang Thi Mai", new DateTime(2004, 12, 01), "TP. Ho Chi Minh", 165, 54, "HE181122", "FTU", 2022, 8.2),
            new Student("Huynh Anh Viet", new DateTime(2002, 01, 25), "Can Tho", 178, 68, "SE160991", "RMIT", 2020, 7.5),
            new Student("Vo Minh Tuan", new DateTime(2003, 07, 19), "Binh Duong", 170, 62, "HE176543", "FPTU", 2021, 6.5),
            new Student("Dang Thi Ngoc", new DateTime(2004, 09, 05), "Vinh Phuc", 160, 48, "SE184789", "HUST", 2022, 9.5),
            new Student("Bui Quoc Huy", new DateTime(2002, 04, 18), "Quang Ninh", 173, 70, "HE163210", "VNU", 2020, 7.2),
            new Student("Ngo Lan Anh", new DateTime(2003, 11, 22), "Thanh Hoa", 166, 55, "SS177788", "NEU", 2021, 8.8)
            };
                Console.WriteLine("Add demo student list successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public void CreateStudent()
        {
            Console.WriteLine("\n--- Add New Student ---");
            string name = inputDataFromUser.GetString("Enter name", AppConstants.MinNameLength, AppConstants.MaxNameLength);
            DateTime dob = inputDataFromUser.GetDateOfBirth("Enter date of birth");
            string address = inputDataFromUser.GetString("Enter address", AppConstants.MinAddressLength, AppConstants.MaxAddressLength);
            double height = inputDataFromUser.GetDouble("Enter height (cm)", AppConstants.MinHeight, AppConstants.MaxHeight);
            double weight = inputDataFromUser.GetDouble("Enter weight (kg)", AppConstants.MinWeight, AppConstants.MaxWeight);
            string studentId = inputDataFromUser.GetStudentId("Enter student ID");
            string university = inputDataFromUser.GetString("Enter university", AppConstants.MinNameLength, AppConstants.MaxUniversityLength);
            int academicYear = inputDataFromUser.GetInt("Enter academic year", AppConstants.MinAcademicYear, DateTime.Now.Year);
            double gpa = inputDataFromUser.GetDouble("Enter GPA", AppConstants.MinGpa, AppConstants.MaxGpa);

            var newStudent = new Student(name, dob, address, height, weight, studentId, university, academicYear, gpa);
            students.Add(newStudent);

            Console.WriteLine("\nStudent created successfully!");
            Console.WriteLine(newStudent.ToString());
        }

        public Student? FindStudentById(int id)
        {
            return students.FirstOrDefault(s => s.Id == id);
        }

        public void DisplayAllStudents()
        {
            Console.WriteLine("\n--- All Students ---");
            if (!students.Any())
            {
                Console.WriteLine("No students in the list.");
                return;
            }
            foreach (var student in students.OrderBy(s => s.Id))
            {
                Console.WriteLine(student.ToString());
            }
        }

        public void DisplayStudentById()
        {
            Console.WriteLine("\n--- Find Student by ID ---");
            int id = inputDataFromUser.GetInt("Enter student internal ID to find", students.Min(s => s.Id), students.Max(s => s.Id));
            var student = FindStudentById(id);

            if (student != null)
            {
                Console.WriteLine("Student found:");
                Console.WriteLine(student.ToString());
            }
            else
            {
                Console.WriteLine("No student found with that ID.");
            }
        }

        public void UpdateStudent()
        {
            Console.WriteLine("\n--- Update Student ---");
            int id = inputDataFromUser.GetInt("Enter student internal ID to update from: ", students.Min(s => s.Id), students.Max(s => s.Id));
            var student = FindStudentById(id);

            if (student == null)
            {
                Console.WriteLine("No student found with that ID.");
                return;
            }

            Console.WriteLine("Enter new information (blank to keep current value):");

            Console.Write($"Update Name ({student.Name}): ");
            string? name = Console.ReadLine();
            if (Validate.IsStringValid(name, AppConstants.MinNameLength, AppConstants.MaxNameLength)) student.Name = name;

            Console.Write($"Update GPA ({student.Gpa}): ");
            string? gpaStr = Console.ReadLine();
            if (double.TryParse(gpaStr, out double gpa) && Validate.IsDoubleInRange(gpa, AppConstants.MinGpa, AppConstants.MaxGpa))
            {
                student.Gpa = gpa;
            }

            Console.WriteLine("\nStudent updated successfully!");
            Console.WriteLine(student.ToString());
        }

        public void DeleteStudent()
        {
            Console.WriteLine("\n--- Delete Student ---");
            int id = inputDataFromUser.GetInt("Enter student internal ID to delete from: ", 1, students.Max(s => s.Id));
            var student = FindStudentById(id);

            if (student == null)
            {
                Console.WriteLine("No student found with that ID.");
                return;
            }

            students.Remove(student);
            Console.WriteLine("Student deleted successfully.");
        }

    }

}
