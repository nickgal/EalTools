using EalTools.Riff;

namespace EalTools;

public class EalFile
{
    public RiffChunk? RootChunk;

    private BinaryReader _reader;

    public EalFile(string filePath)
    {
        var stream = File.Open(filePath, FileMode.Open);
        _reader = new BinaryReader(stream);
    }

    public EalFile(Stream stream)
    {
        _reader = new BinaryReader(stream);
    }

    public bool Initialize()
    {
        var chunk = ChunkFactory.GetChunk(_reader);
        if (chunk is not RiffChunk riffChunk || riffChunk.FormType != FourCC.Eal)
        {
            return false;
        }

        RootChunk = riffChunk;

        return true;
    }
}
