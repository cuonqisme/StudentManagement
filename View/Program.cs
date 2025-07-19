using StudentManagement.Controller;
using StudentManagement.Model;

var manager = new StudentManager();

bool exit = false;
while (!exit)
{
    Console.WriteLine("\n========== STUDENT MANAGEMENT SYSTEM ==========");
    Console.WriteLine("1. Add a new student");
    Console.WriteLine("2. View all students");
    Console.WriteLine("3. Find student by ID");
    Console.WriteLine("4. Update student information");
    Console.WriteLine("5. Delete a student");
    Console.WriteLine("6. Show academic performance percentage");
    Console.WriteLine("7. Show GPA percentage");
    Console.WriteLine("8. Find students by academic performance");
    Console.WriteLine("9. Save student to file");
    Console.WriteLine("10. Load student from file");
    Console.WriteLine("11. Import Demo Data");
    Console.WriteLine("0. Exit Program");
    Console.WriteLine("=============================================");
    Console.Write("Enter your choice: ");

    string? choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            manager.CreateStudent();
            break;
        case "2":
            manager.DisplayAllStudents();
            break;
        case "3":
            manager.DisplayStudentById();
            break;
        case "4":
            manager.UpdateStudent();
            break;
        case "5":
            manager.DeleteStudent();
            break;
        //case "6":
        //    manager.DisplayRankingPercentage();
        //    break;
        //case "7":
        //    manager.DisplayGpaPercentage();
        //    break;
        //case "8":
        //    manager.DisplayStudentsByRanking();
        //    break;
        //case "9":
        //    manager.SaveDataToFile();
        //    break;
        //case "10":
        //    manager.LoadDataFromFile();
        //    break;
        case "11":
            manager.DemoData();
            break;
        case "0":
            exit = true;
            Console.WriteLine("Exiting program...!");
            break;
        default:
            Console.WriteLine("Invalid choice. Please try again.");
            break;
    }
}