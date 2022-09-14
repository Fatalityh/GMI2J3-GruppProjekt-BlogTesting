// https://makolyte.com/csharp-how-to-unit-test-code-that-reads-and-writes-to-the-console/

namespace BlogTesting.BlogTesting
{
    public interface IDateTime
    {
        public DateTime Now { get { return DateTime.Now; } }
    }
}
