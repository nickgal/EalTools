using EalTools.Eal;
using EalTools.Riff;

namespace EalTools.Tests;

public class ChunkTests
{
    EalFile EalFile;

    [SetUp]
    public void Setup()
    {
        var stream = FixtureFileLoader.LoadFileToStream("Fixtures/Eal", "Example.eal");
        EalFile = new EalFile(stream);
        EalFile.Initialize();
    }

    [Test]
    public void Parse_DenvChunk()
    {
        var chunk = EalFile.RootChunk.FindSubChunk<DenvChunk>();
        Assert.That(chunk.ListenerProperties, Is.InstanceOf<EaxListenerProperties>());
    }

    [Test]
    public void Parse_DfilChunk()
    {
        var chunk = EalFile.RootChunk.FindSubChunk<DfilChunk>();
        Assert.That(chunk.Filepath, Is.EqualTo(string.Empty));
    }

    [Test]
    public void Parse_DsrcChunk()
    {
        var chunk = EalFile.RootChunk.FindSubChunk<DsrcChunk>();
        Assert.That(chunk.SourceAttributes, Is.InstanceOf<EaxSourceAttributes>());
    }

    [Test]
    public void Parse_FilsChunk()
    {
        var expectedFilepaths = new List<string> { @"C:\Program Files\EAGLE\Drum.wav" };
        var listChunk = EalFile.RootChunk.FindListOfForm(FourCC.Srcp);
        var chunk = listChunk.FindSubChunk<FilsChunk>();

        Assert.IsTrue(chunk.Filepaths.SequenceEqual(expectedFilepaths));
    }

    [Test]
    public void Parse_LisaChunk()
    {
        var chunk = EalFile.RootChunk.FindSubChunk<LisaChunk>();

        Assert.That(chunk.ListenerAttributes, Is.InstanceOf<EaxListenerAttributes>());
    }

    [Test]
    public void Parse_LispChunk()
    {
        var listChunk = EalFile.RootChunk.FindListOfForm(FourCC.Envp);
        var chunk = listChunk.FindSubChunk<LispChunk>();

        Assert.That(chunk.ListenerProperties, Has.Count.EqualTo(3));
    }


    [Test]
    public void Parse_MajvChunk()
    {
        var chunk = EalFile.RootChunk.FindSubChunk<MajvChunk>();
        Assert.That(chunk.MajorVersion, Is.EqualTo(2));
    }

    [Test]
    public void Parse_MinvChunk()
    {
        var chunk = EalFile.RootChunk.FindSubChunk<MinvChunk>();
        Assert.That(chunk.MinorVersion, Is.EqualTo(1));
    }

    [Test]
    public void Parse_NamsChunk()
    {
        var expectedNames = new List<string> { "Back Room", "Front Room", "Hallway" };
        var listChunk = EalFile.RootChunk.FindListOfForm(FourCC.Envp);
        var chunk = listChunk.FindSubChunk<NamsChunk>();

        Assert.IsTrue(chunk.Names.SequenceEqual(expectedNames));
    }

    [Test]
    public void Parse_NumChunk()
    {
        var listChunk = EalFile.RootChunk.FindListOfForm(FourCC.Envp);
        var chunk = listChunk.FindSubChunk<NumChunk>();

        Assert.That(chunk.Number, Is.EqualTo(3));
    }

    [Test]
    public void Parse_RiffChunk()
    {
        var riffChunk = EalFile.RootChunk;
        Assert.That(riffChunk, Is.Not.Null);
        Assert.That(riffChunk?.FormType, Is.EqualTo(FourCC.Eal));
    }

    [Test]
    public void Parse_SrcaChunk()
    {
        var listChunk = EalFile.RootChunk.FindListOfForm(FourCC.Srcp);
        var chunk = listChunk.FindSubChunk<SrcaChunk>();

        Assert.That(chunk.SourceAttributes[0], Is.InstanceOf<EaxSourceAttributes>());
    }
}
