using System;

// this is to print the first menu

namespace TabloidCLI.UserInterfaceManagers
{
    public class MainMenuManager : IUserInterfaceManager
    {
        private const string CONNECTION_STRING = 
            @"Data Source=localhost\SQLEXPRESS;Database=TabloidCLI;Integrated Security=True";

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
                    Console.WriteLine("Good bye");
                    break;
                default:
                    Console.WriteLine("Invalid Selection");
                    return this;
            }

            void Color()
            {
                Console.BackgroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), str, true);
                Console.Clear();
            }

            Console.WriteLine("Hello human, here is a pleasant greetings for you!");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("");

            Console.WriteLine("Main Menu");

            Console.WriteLine(" 1) My Journal Management");
            Console.WriteLine(" 2) Blog Management");
            Console.WriteLine(" 3) Author Management");
            Console.WriteLine(" 4) Post Management");
            Console.WriteLine(" 5) Tag Management");
            Console.WriteLine(" 6) Search by Tag");
            Console.WriteLine(" 0) Exit");

            Console.Write("> ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1": throw new NotImplementedException();
                case "2": throw new NotImplementedException();
                case "3": return new AuthorManager(this, CONNECTION_STRING);
                case "4": return new PostManager(this, CONNECTION_STRING);
                case "5": return new TagManager(this, CONNECTION_STRING);
                case "6": return new SearchManager(this, CONNECTION_STRING);
                case "0":
                    Console.WriteLine("Good bye");
                    return null;
                default:
                    Console.WriteLine("Invalid Selection");
                    return this;
            }
        }
    }
}
