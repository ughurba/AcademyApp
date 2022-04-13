using Business.Services;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Utilities.Helper;

namespace AcademyApp.Controllers
{
    class GroupController
    {
        private GroupService groupService;
        public GroupController()
        {
            groupService = new GroupService();
        }
        public void CreateGroup()
        {
        EnterName:
            Extention.Print(ConsoleColor.Green, $"Group Name");
            string name = Console.ReadLine();

            Extention.Print(ConsoleColor.Green, $"Group Size");
            string groupSize = Console.ReadLine();
            int size;


            bool isSize = int.TryParse(groupSize, out size);
            if (isSize)
            {
                for (int i = 0; i < size; i++)
                {
                    Group group = new Group
                    {
                        Name = name,
                        MaxSize = size

                    };
                    groupService.Create(group);
                    Extention.Print(ConsoleColor.Green, $"Id:{group.Id}\nName:{group.Name} created");
                    StudentController studentController = new StudentController();
                    studentController.CreateStudent();
                }
                        
            }
            else
            {
                Extention.Print(ConsoleColor.Red, "Duzgun daxil et");
                goto EnterName;
            }
        }
        public void GetAllGroup()
        {
            Extention.Print(ConsoleColor.Blue,"1-Get Group by Id\n" +
                "2-GetAll Group By Name\n" +
                "3-GetAll");
          
            int num = int.Parse(Console.ReadLine());
            if(num == 1)
            {
                Extention.Print(ConsoleColor.Cyan, "Write Id please");
                int id = int.Parse(Console.ReadLine());
                Extention.Print(ConsoleColor.Green, $"{groupService.GetGroup(id).Name}");
            }else if(num == 2)
            {
                Extention.Print(ConsoleColor.Cyan, "Write Name please");
                string name = Console.ReadLine();
                foreach (var item in groupService.GetAll(name))
                {
                    Extention.Print(ConsoleColor.Green, $"Id{item.Id}\nName:{item.Name}");
                }
            }else if (num == 3)
            {
                foreach (var item in groupService.GetAll())
                {
                    Extention.Print(ConsoleColor.Yellow, $"{item.Name}");
                }
            }
          
        }
        public void RemoveGroup()
        {
            Extention.Print(ConsoleColor.Cyan,"Write Id please");
            int id = int.Parse(Console.ReadLine());
            Extention.Print(ConsoleColor.Green, $"{groupService.Delete(id).Name}");
            
        }
       //public void GetAllByName()
       // {
       //     Extention.Print(ConsoleColor.Cyan,"Write Name please");
       //     string name = Console.ReadLine();
       //     foreach (var item in groupService.GetAll(name))
       //     {
       //         Extention.Print(ConsoleColor.Green, $"Id{item.Id}\nName:{item.Name}");
       //     }
            
           
       // }
       // public void GetGroupById()
       // {
       //     Extention.Print(ConsoleColor.Cyan, "Write Id please");
       //     int id = int.Parse(Console.ReadLine());
       //     Extention.Print(ConsoleColor.Green, $"{groupService.GetGroup(id).Name}");
       // }
        
    }
}
