// https://makolyte.com/csharp-how-to-unit-test-code-that-reads-and-writes-to-the-console/

namespace BlogTesting.BlogTesting
{
    public interface IConsoleIO
    {
        void WriteLine(string s);
        string ReadLine();
    }
}
