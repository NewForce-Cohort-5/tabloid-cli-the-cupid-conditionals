//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using TabloidCLI.Models;
//using TabloidCLI.Repositories;
//using TabloidCLI.UserInterfaceManagers;

//namespace TabloidCLI
//{
//    internal class JournalDetailManager : IUserInterfaceManager
//    {

//        private IUserInterfaceManager _parentUI;
//        private JournalRepository _journalRepository;
//        private int _journalId;

//        public JournalDetailManager(IUserInterfaceManager parentUI, string connectionString, int authorId)
//        {
//            _parentUI = parentUI;
//            _journalRepository = new JournalRepository(connectionString);
//        }

//        public IUserInterfaceManager Execute()
//        {
//            Journal journal = _journalRepository.Get(_journalId);
//            Console.WriteLine($"{journal.Title} Details");
//            Console.WriteLine(" 1) View");
//            //Console.WriteLine(" 2) View Blog Posts");
//            //Console.WriteLine(" 3) Add Tag");
//            //Console.WriteLine(" 4) Remove Tag");
//            Console.WriteLine(" 0) Go Back");

//            Console.Write("> ");
//            string choice = Console.ReadLine();
//            switch (choice)
//            {
//                case "1":
//                    View();
//                    return this;
//                //case "2":
//                //    ViewBlogPosts();
//                //    return this;
//                //case "3":
//                //    AddTag();
//                //    return this;
//                //case "4":
//                //    RemoveTag();
//                //    return this;
//                //case "0":
//                    return _parentUI;
//                default:
//                    Console.WriteLine("Invalid Selection");
//                    return this;
//            }
//        }

//        private void View()
//        {
//            Journal journal = _journalRepository.Get(_journalId);
//            Console.WriteLine($"Title: {journal.Title}");
//            Console.WriteLine($"Content: {journal.Content}");
//            Console.WriteLine();
//        }

//        //private void ViewBlogPosts()
//        //{
//        //    List<Post> posts = _postRepository.GetByAuthor(_journalId);
//        //    int num = 0;
//        //    foreach (Post post in posts)
//        //    {
//        //        num++;
//        //        Console.WriteLine($" {num} :  {post.Title}");
//        //    }
//        //    Console.WriteLine();
//        //}



//    }
//}
