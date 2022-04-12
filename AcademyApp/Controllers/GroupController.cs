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
                Group group = new Group
                {
                    Name = name,
                    MaxSize = size
                };

                groupService.Create(group);
                Extention.Print(ConsoleColor.Green, $"{group.Name} created");
            }
            else
            {
                Extention.Print(ConsoleColor.Red, "Duzgun daxil et");
                goto EnterName;
            }
        }
        public void GetAllGroup()
        {
            
            //string name2 = Console.ReadLine();

            foreach (var item in groupService.GetAll())
            {
                Extention.Print(ConsoleColor.Yellow, $"{item.Name}");
            }
        }
        public void RemoveGroup()
        {
            Extention.Print(ConsoleColor.Cyan,"Write Id please");
            int id = int.Parse(Console.ReadLine());
            Extention.Print(ConsoleColor.Green, $"{groupService.Delete(id).Name}");
            
        }
       public void GetAllByName()
        {
            Extention.Print(ConsoleColor.Cyan,"Write Name please");
            string name = Console.ReadLine();
            foreach (var item in groupService.GetAll(name))
            {
                Extention.Print(ConsoleColor.Green, $"Id{item.Id}\nName:{item.Name}");
            }
            
           
        }
    }
}
