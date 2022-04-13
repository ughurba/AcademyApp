using AcademyApp.Controllers;
using System;
using Utilities.Helper;

namespace AcademyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Extention.Print(ConsoleColor.Green, "Welcome");
            while (true)
            {
                StudentController studentController = new StudentController();
                GroupController groupController = new GroupController();
                Extention.Print(ConsoleColor.Cyan, "1-Create Group\n" +
                    "2-Update Group\n" +
                    "3-Remove Group\n" +
                    "4-GetAll Group and Get Group\n");
                string num = Console.ReadLine();
                int input;
                bool IsNum = int.TryParse(num, out input);
                if (IsNum && input < 7 && input > 0)
                {
                    switch (input)
                    {
                        case (int)Extention.Menu.CreateGroup:
                            groupController.CreateGroup();
                            break;
                        case 2:
                            break;
                        case (int)Extention.Menu.RemoveGroup:
                            groupController.RemoveGroup();
                            break;

                        case (int)Extention.Menu.GetAllGroup:
                            groupController.GetAllGroup();
                            break;
                   

                    }
                }

            }
        }
    }
}
