namespace EalTools.Riff;

public class MajChunk : Chunk
{
    public int MajorVersion { get; set; }

    public MajChunk()
    {
        ChunkId = FourCC.Majv;
    }

    public override void Initialize(byte[] data)
    {
        base.Initialize(data);
        MajorVersion = _reader.ReadInt32();
    }
}
