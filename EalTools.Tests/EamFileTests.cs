using NUnit.Framework;

namespace EalTools.Tests
{
    public class EamFileTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase("Eam", "Example.eam", true)]
        [TestCase("Eal", "Example.eal", false)]
        [TestCase("Other", "eagle-tools-logo.webp", false)]
        public void Initializes_EamFile(string directory, string filename, bool result)
        {
            var stream = FixtureFileLoader.LoadFileToStream($"Fixtures/{directory}", filename);
            var eamFile = new EamFile(stream);

            Assert.That(eamFile.Initialize(), Is.EqualTo(result));
        }
    }
}
