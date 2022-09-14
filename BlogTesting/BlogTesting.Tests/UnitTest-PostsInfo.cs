using NUnit.Framework;
using BlogTesting;
using static BlogTesting.PostsClass;

namespace BlogTesting.Tests
{
    [TestFixture]
    internal class UnitTest_PostsInfo
    {
        private PostsInfo _postsInfo;

        [SetUp]
        public void SetUp()
        {
            _postsInfo = new PostsInfo();
        }

        [Test]
        public void TestToString()
        {
            _postsInfo = new PostsInfo();
            _postsInfo.PosterName = "Auan";
            _postsInfo.DateOfPost = DateTime.Now;
            _postsInfo.PosterTitle = "Some Title";
            _postsInfo.PosterComment = "Some post";

            string expectedTostring = $"{_postsInfo.DateOfPost}\n  {_postsInfo.PosterTitle}\n     {_postsInfo.PosterName}\n{_postsInfo.PosterComment}\n";

            Assert.AreEqual(expectedTostring, _postsInfo.ToString());
        }
    }
}
