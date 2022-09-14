using System;
using System.Collections.Generic;

namespace BlogTesting
{
    class PostsInfo
    {
        public string PosterName { get; set; }
        public string PosterTitle { get; set; }
        public string PosterComment { get; set; }
        public DateTime DateOfPost { get; set; }

        public override string ToString()
        { // Outputs everything in the "Show data of people" option in menu
            return $"{DateOfPost}\n  {PosterTitle}\n     {PosterName}\n{PosterComment}\n";
        }
    }
}