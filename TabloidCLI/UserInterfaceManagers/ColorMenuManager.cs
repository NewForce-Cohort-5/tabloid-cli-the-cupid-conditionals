using System;

// this is to print the first menu

namespace TabloidCLI.UserInterfaceManagers
{
    public class ColorMenuManager : IUserInterfaceManager
    {
        private readonly IUserInterfaceManager _parentUI;


        public ColorMenuManager(IUserInterfaceManager parentUI, string connectionString)
        {
            _parentUI = parentUI;

        }

        public IUserInterfaceManager Execute()
        {

            Console.WriteLine("Color Choices");

            Console.WriteLine(" 1) Dark Blue");
            Console.WriteLine(" 2) Dark Green");
            Console.WriteLine(" 3) Dark Cyan");
            Console.WriteLine(" 4) Dark Red");
            Console.WriteLine(" 5) Dark Magenta");
            Console.WriteLine(" 6) Dark Yellow");
            Console.WriteLine(" 7) Gray");
            Console.WriteLine(" 8) Dark Gray");
            Console.WriteLine(" 9) Blue");
            Console.WriteLine(" 10) Green");
            Console.WriteLine(" 0) Exit");

            string str = Console.ReadLine();
            switch (str)
            {
                case "1":
                    Color();
                    return _parentUI;

                case "2":
                    Color();
                    return _parentUI;

                case "3":
                    Color();
                    return _parentUI;

                case "4":
                    Color();
                    return _parentUI;

                case "5":
                    Color();
                    return _parentUI;

                case "6":
                    Color();
                    return _parentUI;
                case "7":
                    Color();
                    return _parentUI;
                case "8":
                    Color();
                    return _parentUI;
                case "9":
                    Color();
                    return _parentUI;
                case "10":
                    Color();
                    return _parentUI;
                case "0":
                    Console.WriteLine("--------------------");
                    return _parentUI;
                default:
                    Console.WriteLine("Invalid Selection");
                    return this;

            }

            void Color()
            {
                Console.BackgroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), str, true);
                
            }
        }
    }
}
