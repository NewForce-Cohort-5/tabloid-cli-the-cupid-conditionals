using System;
using System.Collections.Generic;
using TabloidCLI.Models;
using TabloidCLI.Repositories;

namespace TabloidCLI.UserInterfaceManagers
{
    public class PostManager : IUserInterfaceManager
    {
        private const string CONNECTION_STRING =
       @"Data Source=localhost\SQLEXPRESS;Database=TabloidCLI;Integrated Security=True";

        private readonly IUserInterfaceManager _parentUI;
        private AuthorRepository _authorRepository;
        private BlogRepository _blogRepository;
        private PostRepository _postRepository;
        private string _connectionString;

        public PostManager(IUserInterfaceManager parentUI, string connectionString)
        {


            _parentUI = parentUI;
            _postRepository = new PostRepository(connectionString);
            _authorRepository = new AuthorRepository(connectionString);
            _blogRepository = new BlogRepository(connectionString);
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
                    Remove();
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
            
            List<Post> posts = _postRepository.GetAll();
            foreach (Post post in posts)
            {
                Console.WriteLine($"\nTitle: {post.Title}");
                Console.WriteLine($"\nURL: {post.Url}\n");
            }
        }

        private Author AChoose(string prompt = null)
        {
            if (prompt == null)
            {
                prompt = "Please choose an Author:";
            }

            Console.WriteLine(prompt);

            List<Author> authors = _authorRepository.GetAll();

            for (int i = 0; i < authors.Count; i++)
            {
                Author author = authors[i];
                Console.WriteLine($" {i + 1}) {author.FullName}");
            }
            Console.Write("> ");

            string input = Console.ReadLine();
            try
            {
                int choice = int.Parse(input);
                return authors[choice - 1];
            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid Selection");
                return null;
            }
        }

        private Blog BChoose(string prompt = null)
        {
            if (prompt == null)
            {
                prompt = "Please choose a Blog:";
            }

            Console.WriteLine(prompt);

            List<Blog> blogs = _blogRepository.GetAll();

            for (int i = 0; i < blogs.Count; i++)
            {
                Blog blog = blogs[i];
                Console.WriteLine($" {i + 1}) {blog.Title}");
            }
            Console.Write("> ");

            string input = Console.ReadLine();
            try
            {
                int choice = int.Parse(input);
                return blogs[choice - 1];
            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid Selection");
                return null;
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
            //post.PublishDateTime =DateTime.Now;

            //list of authors and select
                        
            post.Author = AChoose("Please select an author");
            post.Blog = BChoose("Please select an blog");
            
            

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

            private void Remove()
            {
                Post postToDelete = Choose("Which post would you like to remove?");
                if (postToDelete != null)
                {
                    _postRepository.Delete(postToDelete.Id);
                }
            }
        }
    }


