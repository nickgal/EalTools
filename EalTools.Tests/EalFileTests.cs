using NUnit.Framework;

namespace EalTools.Tests
{
    public class EalFileTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase("eagle-tools-logo.webp", false)]
        [TestCase("Environments1.eal", true)]
        [TestCase("Environments2.eal", true)]
        [TestCase("Environments3.eal", true)]
        [TestCase("Environments4.eal", true)]
        [TestCase("Environments5.eal", true)]
        [TestCase("Example.eal", true)]
        [TestCase("Obstacles.eal", true)]
        public void Initializes_EalFile(string filename, bool result)
        {
            var stream = FixtureFileLoader.LoadFileToStream("Fixtures/Eal", filename);
            var ealFile = new EalFile(stream);

            Assert.That(ealFile.Initialize(), Is.EqualTo(result));
        }
    }
}
