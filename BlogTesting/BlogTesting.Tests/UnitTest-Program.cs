using NUnit.Framework;
using BlogTesting;
using static BlogTesting.Program;

namespace BlogTesting.Tests
{
    public class Tests
    {
        [TestFixture]
        public class NumberService_IsNumberShould
        {
            private NumberService _numberService;

            [SetUp]
            public void SetUp()
            {
                _numberService = new NumberService();
            }

            [Test]
            public void IsNumber_MainMenu_InputIs0_ReturnFalse()
            {
                var result = _numberService.IsNumber(0);

                Assert.IsFalse(result, "0 should not be entered.");
            }

            public void IsNumber_MainMenu_InputIs5_ReturnFalse()
            {
                var result = _numberService.IsNumber(5);

                Assert.IsFalse(result, "5 should not be entered.");
            }

            [TestCase(-1)]
            [TestCase(0)]
            [TestCase(5)]
            public void IsNumber_MainMenu_ValuesHigherThan4OrLessThan1_ReturnFalse(int value)
            {
                var result = _numberService.IsNumber(value);

                Assert.IsFalse(result, $"{value} should not be higher than 4 or less than 1.");
            }
        }
    }
}