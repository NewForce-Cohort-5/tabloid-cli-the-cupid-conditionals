using System;

namespace TabloidCLI.UserInterfaceManagers
{
    public class ColorMenuManager : IUserInterfaceManager
    {
        private const string connection_string =
            @"data source=localhost\sqlexpress;database=tabloidcli;integrated security=true";

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
            Console.WriteLine(" 0) Continue without color");

            string str = Console.ReadLine();
            switch (str)
            {
                case "1":
                    Color();
                    break;

                case "2":
                    Color();
                    break;

                case "3":
                    Color();
                    break;

                case "4":
                    Color();
                    break;

                case "5":
                    Color();
                    break;

                case "6":
                    Color();
                    break;
                case "7":
                    Color();
                    break;
                case "8":
                    Color();
                    break;
                case "9":
                    Color();
                    break;
                case "10":
                    Color();
                    break;
                case "0":
                    Console.WriteLine("--------------------");
                    break;
                default: Console.WriteLine("Invalid Selection");
                    
            }

            void Color()
            {
                Console.BackgroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), str, true);
                ConsoleColor background = Console.BackgroundColor;

                Console.WriteLine($"You chose {background} as your new background color...Enjoy!");
                Console.Clear();
            }
        }
    }
}