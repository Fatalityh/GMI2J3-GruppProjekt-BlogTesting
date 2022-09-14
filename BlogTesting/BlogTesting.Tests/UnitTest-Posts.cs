using NUnit.Framework;
using BlogTesting;
using static BlogTesting.PostsClass;
using Moq;
using BlogTesting.BlogTesting;

namespace BlogTesting.Tests
{
    [TestFixture]
    internal class UnitTest_Posts
    {
        private PostsClass _postsClass;
        private Mock<IConsoleIO> mockConsoleIO;
        private Mock<IDateTime> dateTimeMock;
        private PostsInfo _auanPostsInfo;
        private PostsInfo _hildaPostsInfo;
        
        [SetUp]
        public void SetUp()
        {
            mockConsoleIO = new Mock<IConsoleIO>();
            _postsClass = new PostsClass();
            dateTimeMock = new Mock<IDateTime>();


            _auanPostsInfo = new PostsInfo();
            _auanPostsInfo.PosterName = "Auan";
            _auanPostsInfo.DateOfPost = DateTime.Now;
            _auanPostsInfo.PosterTitle = "Random Title";
            _auanPostsInfo.PosterComment = "Random Post";


            _hildaPostsInfo = new PostsInfo();
            _hildaPostsInfo.PosterName = "Hilda";
            _hildaPostsInfo.DateOfPost = DateTime.Now;
            _hildaPostsInfo.PosterTitle = "Title2";
            _hildaPostsInfo.PosterComment = "Post2";


            mockConsoleIO.SetupSequence(p => p.ReadLine())
                .Returns(_auanPostsInfo.PosterName)
                .Returns(_auanPostsInfo.PosterTitle)
                .Returns(_auanPostsInfo.PosterComment);

            dateTimeMock.Setup(d => d.Now).Returns(DateTime.Now);
            _postsClass.AddPostData(mockConsoleIO.Object, dateTimeMock.Object);


            mockConsoleIO.SetupSequence(p => p.ReadLine())
                .Returns(_hildaPostsInfo.PosterName)
                .Returns(_hildaPostsInfo.PosterTitle)
                .Returns(_hildaPostsInfo.PosterComment);

            dateTimeMock.Setup(d => d.Now).Returns(DateTime.Now);
            _postsClass.AddPostData(mockConsoleIO.Object, dateTimeMock.Object);
        }

        [Test]
        public void TestAddPostData()
        {
            Assert.AreEqual(_auanPostsInfo.ToString(), ((PostsInfo)_postsClass.Posts[0]).ToString());
        }

        [Test]
        public void TestOutputPersonDataSortingLateToEarly()
        {
            mockConsoleIO.Setup(c => c.ReadLine()).Returns("2");
            _postsClass.OutputPersonData(mockConsoleIO.Object);

            Assert.AreEqual(_hildaPostsInfo.ToString(), ((PostsInfo)_postsClass.Posts[0]).ToString());
        }

        [Test]
        public void TestOutputPersonDataSortingEarlyToLate()
        {
            mockConsoleIO.Setup(c => c.ReadLine()).Returns("1");
            _postsClass.OutputPersonData(mockConsoleIO.Object);

            Assert.AreEqual(_auanPostsInfo.ToString(), ((PostsInfo)_postsClass.Posts[0]).ToString());
        }

        [Test]
        public void TestOutputPersonInvaildOption()
        {
            mockConsoleIO.Setup(c => c.ReadLine()).Returns("3");
            Exception ex = Assert.Throws<Exception>(() => _postsClass.OutputPersonData(mockConsoleIO.Object));

            Assert.AreEqual("Invalid option!", ex.Message);
        }

        [Test]
        public void TestOutputSearchParameterReturnsPost()
        {
            mockConsoleIO.Setup(c => c.ReadLine()).Returns(_hildaPostsInfo.PosterName);
            _postsClass.OutputSearchParameter(mockConsoleIO.Object);

            mockConsoleIO.Verify(c => c.WriteLine(_hildaPostsInfo.ToString()), Times.Once);
        }

        [Test]
        public void TestOutputSearchParameterNoMatch()
        {
            string searchPhrase = "Random post";
            mockConsoleIO.Setup(c => c.ReadLine()).Returns(searchPhrase);
            _postsClass.OutputSearchParameter(mockConsoleIO.Object);

            mockConsoleIO.Verify(c => c.WriteLine($"Invalid, could not find a post containing {searchPhrase}"), Times.Once);
        }


    }
}
