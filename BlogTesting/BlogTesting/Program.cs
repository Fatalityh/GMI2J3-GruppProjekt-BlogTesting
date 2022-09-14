using BlogTesting.BlogTesting;
using System;
using System.Collections.Generic;

namespace BlogTesting
{
    class Program
    {
        private static readonly IConsoleIO ConsoleIO;
        private static readonly IDateTime _IDateTime;
        static void Main(string[] args)
        {
            PostsClass postsInfo = new PostsClass(); // Creates an instance of AddToFile


            bool menuChoice = true;

            while (menuChoice)
            {
                Console.WriteLine("Hello! What do you want to do today?");
                Console.WriteLine("1. Create a new post");
                Console.WriteLine("2. Show all posts");
                Console.WriteLine("3. Search older posts");
                Console.WriteLine("4. Exit");
                int buttonPressed = int.Parse(Console.ReadKey().KeyChar.ToString());

                switch (buttonPressed)
                {
                    case 1:
                        postsInfo.AddPostData(ConsoleIO, _IDateTime);
                        break;

                    case 2:
                        postsInfo.OutputPersonData(ConsoleIO);
                        break;

                    case 3:
                        postsInfo.OutputSearchParameter(ConsoleIO);
                        break;

                    case 4:
                        Console.WriteLine("Choice 3");
                        menuChoice = false;
                        break;
                }
            }
        }
        public class NumberService
        {
            public bool IsNumber(int candidate)
            {
                if (candidate > 4 || candidate < 1)
                {
                    return false;
                }
                throw new NotImplementedException("Please create a test first.");
            }
        }
    }
}
