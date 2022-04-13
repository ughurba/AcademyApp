using Business.Services;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Utilities.Helper;

namespace AcademyApp.Controllers
{
    class StudentController
    {
        GroupService groupService = new GroupService();
        StudentService studentService { get; set; }
        public StudentController()
        {
            studentService = new StudentService();    
        }
        public void CreateStudent()
        {
        EnterName:

            Extention.Print(ConsoleColor.Green, $"Student Size");
            int size;

            bool isSize = int.TryParse(Console.ReadLine(), out size);
            if (isSize)
            {
                for (int i = 0; i < size; i++)
                {
                    Extention.Print(ConsoleColor.Blue, $"Student Name");
                    string name = Console.ReadLine();
                    Extention.Print(ConsoleColor.Blue, $"Student Surname");
                    string surname = Console.ReadLine();
                    
                    Student student = new Student
                    {
                        Name = name,
                        Surname = surname,
                    };
                    studentService.Create(student);
                    groupService.AddStudent(student);
                    Extention.Print(ConsoleColor.Green, $"Id:{student.Id}\nName:{student.Name}\nSurname:{student.Surname}\ncreated");
                    Extention.Print(ConsoleColor.Red,"************************************");
                }
          
            }
            else
            {
                Extention.Print(ConsoleColor.Red, "Duzgun daxil et");
                goto EnterName;
            }
        }
        public void GetAllStudent()
        {
            Extention.Print(ConsoleColor.Blue, "1-Get Student by Id\n" +
                "2-GetAll Student By Name\n" +
                "3-GetAll");

            int num = int.Parse(Console.ReadLine());
            if (num == 1)
            {
                Extention.Print(ConsoleColor.Cyan, "Write Id please");
                int id = int.Parse(Console.ReadLine());
                Extention.Print(ConsoleColor.Green, $"{studentService.GetStudent(id).Name}");
            }
            else if (num == 2)
            {
                Extention.Print(ConsoleColor.Cyan, "Write Name please");
                string name = Console.ReadLine();
                foreach (var item in studentService.GetAll(name))
                {
                    Extention.Print(ConsoleColor.Green, $"Id{item.Id}\nName:{item.Name}");
                }
            }
            else if (num == 3)
            {
                foreach (var item in studentService.GetAll())
                {
                    Extention.Print(ConsoleColor.Yellow, $"{item.Name}");
                }
            }

        }

    }
}
