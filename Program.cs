using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            Student CFSI = new Student();
            CFSI.AddStudent(students, 1, "John", "A.", "Doe", 18, 'M');
            CFSI.AddStudent(students, 2, "Jane", "A.", "Doe", 16, 'M');
            CFSI.AddStudent(students, 3, "Jeff", "K.", "Benedicts", 17, 'M');

            while (true)
            {
                Start:
                Console.Clear();
                Console.WriteLine("Student Management System");
                Console.WriteLine("1. View all Students");
                Console.WriteLine("2. Search Students");
                Console.WriteLine("3. Add/Delete Students");
                Console.WriteLine("4. Exit");
                Console.Write("Choice: ");
                string inputStr = Console.ReadLine();
                int input = 0;
                try
                {
                    input = int.Parse(inputStr);
                }
                catch(FormatException)
                {
                    Console.WriteLine("Invalid input. Please try again.");
                    Console.ReadKey();
                    goto Start;
                }

                switch(input)
                {
                    //View All
                    case 1:
                        Console.Clear();
                        foreach (var std in students)
                        {
                            Console.WriteLine($"ID: {std.ID}");
                            Console.WriteLine($"Name: {std.fName} {std.mName} {std.lName}");
                            Console.WriteLine($"Age: {std.Age}");
                            Console.WriteLine($"Gender: {std.Gender}");
                            Console.WriteLine();
                        }
                        Console.WriteLine("Press any key to exit.");
                        Console.ReadKey();
                        break;

                    //Search
                    case 2: 
                        Console.Clear();
                        Console.WriteLine("Search via:");
                        Console.WriteLine("1. ID");
                        Console.WriteLine("2. Name");
                        Console.Write("Choice: ");

                        string searchChoiceStr = Console.ReadLine();
                        int searchChoice = 0;

                        try
                        {
                            searchChoice = int.Parse(searchChoiceStr);
                        }
                        catch(FormatException)
                        {
                            Console.WriteLine("Invalid input. Please try again.");
                            Console.ReadKey();
                            break;
                        }

                        switch(searchChoice) //Search by ID or by Name
                        {
                            //Search by ID
                            case 1:
                                Console.Clear();
                                Console.Write("Input ID: ");
                                string searchIDStr = Console.ReadLine();
                                int searchID = 0;
                                try
                                {
                                    searchID = int.Parse(searchIDStr);
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("Invalid input. Please try again.");
                                    Console.ReadKey();
                                    goto Start;
                                }
                                Student foundStudent = Student.SearchById(students, searchID);

                                Console.Clear();
                                if (foundStudent != null)
                                {
                                    Console.WriteLine($"Found student with ID {searchID}:");

                                    Console.WriteLine($"Name: {foundStudent.fName} {foundStudent.mName} {foundStudent.lName}");
                                    Console.WriteLine($"Age: {foundStudent.Age}");
                                    Console.WriteLine($"Gender: {foundStudent.Gender}");
                                    Console.WriteLine();
                                    Console.ReadKey();
                                }
                                else
                                {
                                    Console.WriteLine($"No student found with ID {searchID}");
                                    Console.ReadKey();
                                }
                                break;

                            //Search by Name
                            case 2:
                                Console.Clear();
                                Console.Write("Input Name: ");

                                string searchName = Console.ReadLine();
                                List<Student> foundStudents = Student.SearchByName(students, searchName);
                                
                                Console.Clear();
                                if (foundStudents.Any())
                                {
                                    if (foundStudents.Count == 1)
                                    {
                                        Console.WriteLine($"Found {foundStudents.Count} student with {searchName}:");
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Found {foundStudents.Count} students with {searchName}:");
                                    }

                                    foreach(Student std in foundStudents)
                                    {
                                        Console.WriteLine($"ID: {std.ID}");
                                        Console.WriteLine($"Name: {std.fName} {std.mName} {std.lName}");
                                        Console.WriteLine($"Age: {std.Age}");
                                        Console.WriteLine($"Gender: {std.Gender}");
                                        Console.WriteLine();
                                    }
                                    Console.WriteLine("Press any key to continue.");
                                    Console.ReadKey();
                                }
                                else
                                {
                                    Console.WriteLine($"No students found with name {searchName}");
                                    Console.ReadKey();
                                }
                                break;
                            default:
                                Console.WriteLine("Invalid input. Please try again.");
                                Console.ReadKey();
                                break;
                        }
                        break;

                    //Add or Delete students
                    case 3:
                        Console.Clear();
                        Console.WriteLine("What would you like to do?");
                        Console.WriteLine("1. Add Student");
                        Console.WriteLine("2. Delete Student by ID");
                        Console.Write("Choice: ");

                        string choiceStr = Console.ReadLine();
                        int choice = 0;

                        try
                        {
                            choice = int.Parse(choiceStr);
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Invalid input. Please try again.");
                            Console.ReadKey();
                        }
                        
                        switch(choice)
                        {
                            // Add Student
                            case 1:
                                Console.Clear();
                                Console.Write("Enter the number of students: ");
                                string numberStr = Console.ReadLine();
                                int numberOfStudents = 0;
                                try
                                {
                                    numberOfStudents = int.Parse(numberStr);
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("Invalid input. Please try again.");
                                    Console.ReadKey();
                                    break;
                                }

                                for (int i = 0; i < numberOfStudents; i++)
                                {
                                    Console.WriteLine($"Enter details for student {i + 1}:");
                                    Console.Write("First Name: ");
                                    string fName = Console.ReadLine();

                                    Console.Write("Middle Name: ");
                                    string mName = Console.ReadLine();

                                    Console.Write("Last Name: ");
                                    string lName = Console.ReadLine();

                                    Console.Write("Age: ");
                                    byte age = byte.Parse(Console.ReadLine());

                                    Console.Write("Gender: ");
                                    char gender = char.Parse(Console.ReadLine());

                                    // Generate the ID based on the index (i + 1)
                                    int id = i + 1;

                                    // Call the AddStudent method to add the student
                                    CFSI.AddStudent(students, id, fName, mName, lName, age, gender);

                                    Console.WriteLine("Student added successfully!");
                                    Console.WriteLine();
                                }
                                break;

                            // Delete Student
                            case 2:
                                Console.Clear();
                                Console.WriteLine("Enter the ID of the student you wish to delete.");
                                Console.Write("ID: ");
                                string _idStr = Console.ReadLine();
                                int _id = 0;
                                try
                                {
                                    _id = int.Parse(_idStr);
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("Invalid input. Please try again.");
                                    Console.ReadKey();
                                    break;
                                }

                                //Deletes student that matches the ID
                                Student studentToRemove = students.FirstOrDefault(s => s.ID == _id);
                                if (studentToRemove != null)
                                {
                                    students.Remove(studentToRemove);
                                    Console.WriteLine("Student removed successfully!");
                                }
                                else
                                {
                                    Console.WriteLine("Student not found!");
                                }
                                break;
                            default:
                                Console.WriteLine("Invalid input. Please try again.");
                                Console.ReadKey();
                                break;
                        }
                        break;

                    //Exit
                    case 4:
                        Console.Clear();
                        Console.WriteLine("Goodbye.");
                        Console.ReadKey();
                        return;
                    default:
                        break;
                }
            }
        }
    }
}
