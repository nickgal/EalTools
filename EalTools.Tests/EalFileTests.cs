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
        [TestCase("Eal", "Environments1.eal", true)]
        [TestCase("Eal", "Environments2.eal", true)]
        [TestCase("Eal", "Environments3.eal", true)]
        [TestCase("Eal", "Environments4.eal", true)]
        [TestCase("Eal", "Environments5.eal", true)]
        [TestCase("Eal", "Example.eal", true)]
        [TestCase("Eal", "Obstacles.eal", true)]
        [TestCase("Eam", "Example.eam", false)]
        [TestCase("Other", "eagle-tools-logo.webp", false)]
        public void Initializes_EalFile(string directory, string filename, bool result)
        {
            var stream = FixtureFileLoader.LoadFileToStream($"Fixtures/{directory}", filename);
            var ealFile = new EalFile(stream);

            Assert.That(ealFile.Initialize(), Is.EqualTo(result));
        }
    }
}
