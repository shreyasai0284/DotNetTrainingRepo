using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentMarksManager
{
    class Program
    {
        static void Main(string[] args)
        {
            // Dictionary mapping Student Name (Key) to a List of Marks (Value)
            Dictionary<string, List<int>> studentRecords = new Dictionary<string, List<int>>();

            bool running = true;
            while (running)
            {
                Console.WriteLine("\n=== Student Marks Manager ===");
                Console.WriteLine("1. Add New Student");
                Console.WriteLine("2. Add Mark to Student");
                Console.WriteLine("3. View Class Performance Report");
                Console.WriteLine("4. Exit");
                Console.Write("Select an option (1-4): ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        AddStudent(studentRecords);
                        break;
                    case "2":
                        AddMark(studentRecords);
                        break;
                    case "3":
                        DisplayReport(studentRecords);
                        break;
                    case "4":
                        running = false;
                        Console.WriteLine("Exiting application. Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please choose between 1 and 4.");
                        break;
                }
            }
        }

        static void AddStudent(Dictionary<string, List<int>> records)
        {
            Console.Write("Enter student name: ");
            string name = Console.ReadLine()?.Trim();

            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Error: Name cannot be empty.");
                return;
            }

            if (records.ContainsKey(name))
            {
                Console.WriteLine($"Error: Student '{name}' already exists.");
            }
            else
            {
                records[name] = new List<int>();
                Console.WriteLine($"Success: Student '{name}' added successfully.");
            }
        }

        static void AddMark(Dictionary<string, List<int>> records)
        {
            Console.Write("Enter student name: ");
            string name = Console.ReadLine()?.Trim();

            if (!records.ContainsKey(name))
            {
                Console.WriteLine($"Error: Student '{name}' not found.");
                return;
            }

            Console.Write("Enter mark to add (0-100): ");
            if (int.TryParse(Console.ReadLine(), out int mark) && mark >= 0 && mark <= 100)
            {
                records[name].Add(mark);
                Console.WriteLine($"Success: Added mark {mark} to {name}.");
            }
            else
            {
                Console.WriteLine("Error: Invalid mark. Please enter an integer between 0 and 100.");
            }
        }

        static void DisplayReport(Dictionary<string, List<int>> records)
        {
            if (records.Count == 0)
            {
                Console.WriteLine("No student records available yet.");
                return;
            }

            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine($"{"Student Name",-20} | {"Marks",-20} | {"Average",-8}");
            Console.WriteLine("--------------------------------------------------");

            foreach (var kvp in records)
            {
                string name = kvp.Key;
                List<int> marks = kvp.Value;
                string marksString = marks.Count > 0 ? string.Join(", ", marks) : "No marks";
                double average = marks.Count > 0 ? marks.Average() : 0.0;

                Console.WriteLine($"{name,-20} | {marksString,-20} | {average,8:F2}");
            }
            Console.WriteLine("--------------------------------------------------");
        }
    }
}