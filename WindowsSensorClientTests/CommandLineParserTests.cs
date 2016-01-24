using WindowsSensorClient;
using CommandLine;
using NUnit.Framework;

namespace WindowsSensorClientTests
{
    /// <summary>
    /// Purpose of these tests is to verify that 3rd party library CommandLineParser works as expected.
    /// </summary>
    [TestFixture]
    public class CommandLineParserTests
    {
        [Test]
        public void TestQuietValueIsParsed()
        {
            var options = new CommandLineParameters();
            var args = new[] {"-q"};
            Parser.Default.ParseArguments(args, options);

            Assert.IsTrue(options.Quiet);
        }

        [Test]
        public void TestSingleRunValueIsParsed()
        {
            var options = new CommandLineParameters();
            var args = new[] { "-s" };
            Parser.Default.ParseArguments(args, options);

            Assert.IsTrue(options.SingleRun);
        }
    }
}