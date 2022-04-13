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
            
                StudentController studentController = new StudentController();
                GroupController groupController = new GroupController();


            int num1;
            do {
                Extention.Print(ConsoleColor.Cyan, "1-Create Group\n");
                 num1  = int.Parse(Console.ReadLine());
                if (num1 == 1)
                {
                    groupController.CreateGroup();
                }
              
            }while (num1 != 1);


            while (true)
            {
                Extention.Print(ConsoleColor.Cyan, "1-Create Group\n" +
                    "2-Update Group\n" +
                    "3-Remove Group\n" +
                    "4-GetAll Group and Get Group\n" +
                    "5-Create Student\n" +
                    "6-Get All Student\n" +
                    "7-Groupun icinde olan studentleri tapin");
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
                        case 5:
                            studentController.CreateStudent();
                            break;
                        case 6:
                            studentController.GetAllStudent();
                            break;
                       
                    }
                }

            }
        }
    }
}
