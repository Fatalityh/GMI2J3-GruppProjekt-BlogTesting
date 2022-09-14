using BlogTesting.BlogTesting;
using System;
using System.Collections.Generic;

namespace BlogTesting
{
    class AddToFile
    {
        List<AddToFile> AddPostsToFile = new List<AddToFile>();

    }

    class PostsClass
    {
        public List<PostsInfo> Posts = new List<PostsInfo>();

        public void AddPostData(IConsoleIO consoleIO, IDateTime idateTime)
        {
            PostsInfo postsUser = new PostsInfo(); // Creates an instance of AddToFile

            consoleIO.WriteLine("\nWrite the name of the person that is posting..."); // Name of the poster 
            string savedPosterName = consoleIO.ReadLine();

            consoleIO.WriteLine($"\nWrite the title of the post {savedPosterName}?"); // Post
            string savedPostTitle = consoleIO.ReadLine();

            consoleIO.WriteLine($"\nWrite your post {savedPosterName}?"); // Post
            string savedPost = consoleIO.ReadLine();

            consoleIO.WriteLine($"\n{savedPost} added to {savedPosterName}\nReturning to Main Menu.\n");


            // Adds all the data into the postUser variable
            postsUser.DateOfPost = idateTime.Now;
            postsUser.PosterName = savedPosterName;
            postsUser.PosterTitle = savedPostTitle;
            postsUser.PosterComment = savedPost;

            Posts.Add(postsUser); // Adds the data above (postUser - variable) into the list persons
        }

        public void OutputPersonData(IConsoleIO consoleIO)
        {
            bool miniMenu = true;

            while (miniMenu == true)
            {
                consoleIO.WriteLine("Choose a sorting option, 1: Early to Late 2: Late to early");
                int buttonPressed = int.Parse(consoleIO.ReadLine());

                switch (buttonPressed)
                {
                    case 1:
                        Posts.Sort((x, y) => DateTime.Compare(x.DateOfPost, y.DateOfPost));
                        //Posts.ForEach(Console.WriteLine);
                        foreach (PostsInfo post in Posts)
                        {
                            consoleIO.WriteLine(post.ToString());
                        }
                        
                        miniMenu = false;
                        break;

                    case 2:
                        Posts.Sort((y, x) => DateTime.Compare(x.DateOfPost, y.DateOfPost));
                        //Posts.ForEach(Console.WriteLine);
                        foreach (PostsInfo post in Posts)
                        {
                            consoleIO.WriteLine(post.ToString());
                        }

                        miniMenu = false;
                        break;

                    default:
                        throw new Exception("Invalid option!");
                }
            }
        }

        public void OutputSearchParameter(IConsoleIO consoleIO)
        {
            consoleIO.WriteLine("Search for a post");
            string savedSearchParameter = consoleIO.ReadLine();
            bool foundMatch = false;

            foreach (PostsInfo post in Posts)
            {
                if (post.PosterName.Contains(savedSearchParameter))
                {
                    consoleIO.WriteLine(post.ToString());
                    foundMatch = true;
                }
            }
            if (!foundMatch)
            {
                consoleIO.WriteLine($"Invalid, could not find a post containing {savedSearchParameter}");
            }
        }
    }
}