using System;
using System.Collections.Generic;
using TabloidCLI.Models;
using TabloidCLI.Repositories;

namespace TabloidCLI.UserInterfaceManagers
{
    public class PostManager : IUserInterfaceManager
    {
        private readonly IUserInterfaceManager _parentUI;
        private PostRepository _postRepository;
        private string _connectionString;

        public PostManager(IUserInterfaceManager parentUI, string connectionString)
        {
            _parentUI = parentUI;
            _postRepository = new PostRepository(connectionString);
            _connectionString = connectionString;
        }
        //connectionString = connecting C# and SQL
        public IUserInterfaceManager Execute()
        {
            Console.WriteLine("Post Menu");
            Console.WriteLine(" 1) List Posts");
            Console.WriteLine(" 2) Post Details");
            Console.WriteLine(" 3) Add Post");
            Console.WriteLine(" 4) Edit Post");
            Console.WriteLine(" 5) Remove Post");
            Console.WriteLine(" 0) Go Back");

            Console.Write("> ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    List();
                    return this;
                case "2":
                    Post post = Choose();
                    if (post == null)
                    {
                        return this;
                    }
                    else
                    {
                        return new PostDetailManager(this, _connectionString, post.Id);
                    }
                case "3":
                    Add();
                    return this;
                case "4":
                    //Edit();
                    return this;
                case "5":
                    // Remove();
                    return this;
                case "0":
                    return _parentUI;
                default:
                    Console.WriteLine("Invalid Selection");
                    return this;
            }
        }

        private void List()
        {
            //Console.WriteLine("Hello");
            List<Post> posts = _postRepository.GetAll();
            foreach (Post post in posts)
            {
                Console.WriteLine($"\nTitle: {post.Title}");
                Console.WriteLine($"\nURL: {post.Url}\n");
            }
        }

        private Post Choose(string prompt = null)
        {
            if (prompt == null)
            {
                prompt = "Please choose an post:";
            }

            Console.WriteLine(prompt);

            List<Post> posts = _postRepository.GetAll();

            for (int i = 0; i < posts.Count; i++)
            {
                Post post = posts[i];
                Console.WriteLine($" {i + 1}) {post.Title}");
            }
            Console.Write("> ");

            string input = Console.ReadLine();
            try
            {
                int choice = int.Parse(input);
                return posts[choice - 1];
            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid Selection");
                return null;
            }
        }

        private void Add()
        {
            Console.WriteLine("New Post");
            Post post = new Post();

            Console.Write("Title: ");
            post.Title = Console.ReadLine();

            Console.Write("URL: ");
            post.Url = Console.ReadLine();

            Console.Write("Publish Date Time: ");
            post.PublishDateTime = DateTime.Parse(Console.ReadLine());

            //Console.Write("Author: ");

            //string userInputAuthor = ;
            //post.Author = Console.ReadLine(); 
            //Author findAuthor = Where(userInputAuthor == Author.Name)

            

                _postRepository.Insert(post);
          }

            //private void Edit()
            //{
            //    Author authorToEdit = Choose("Which author would you like to edit?");
            //    if (authorToEdit == null)
            //    {
            //        return;
            //    }

            //    Console.WriteLine();
            //    Console.Write("New first name (blank to leave unchanged: ");
            //    string firstName = Console.ReadLine();
            //    if (!string.IsNullOrWhiteSpace(firstName))
            //    {
            //        authorToEdit.FirstName = firstName;
            //    }
            //    Console.Write("New last name (blank to leave unchanged: ");
            //    string lastName = Console.ReadLine();
            //    if (!string.IsNullOrWhiteSpace(lastName))
            //    {
            //        authorToEdit.LastName = lastName;
            //    }
            //    Console.Write("New bio (blank to leave unchanged: ");
            //    string bio = Console.ReadLine();
            //    if (!string.IsNullOrWhiteSpace(bio))
            //    {
            //        authorToEdit.Bio = bio;
            //    }

            //    _authorRepository.Update(authorToEdit);
            //}

            //private void Remove()
            //{
            //    Author authorToDelete = Choose("Which author would you like to remove?");
            //    if (authorToDelete != null)
            //    {
            //        _authorRepository.Delete(authorToDelete.Id);
            //    }
            //}
        }
    }


