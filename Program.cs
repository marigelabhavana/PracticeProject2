using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainbow_School
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = "F:\\Practice Project 2\\Rainbow School\\Rainbow School\\students.txt";

            List<Student> students = ReadStudentData(filePath);

            Console.WriteLine("STUDENT DATA:\n");
            Console.WriteLine("NAME \t ID \t MAJOR");
            foreach (var student in students)
            {
                Console.WriteLine($"{student.Name}\t {student.ID}\t {student.Major}");
            }
        }

        static List<Student> ReadStudentData(string filePath)
        {
            List<Student> students = new List<Student>();

            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        string[] data = line.Split(',');

                        if (data.Length == 3)
                        {
                            Student student = new Student
                            {
                                Name = data[0].Trim(),
                                ID = int.Parse(data[1].Trim()),
                                Major = data[2].Trim()
                            };

                            students.Add(student);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            return students;
        }
    }
}
