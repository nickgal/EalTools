namespace EalTools.Riff;

public class MinvChunk : Chunk
{
    public int MinorVersion { get; set; }

    public MinvChunk()
    {
        ChunkId = FourCC.Minv;
    }

    public override void Initialize(byte[] data)
    {
        base.Initialize(data);
        MinorVersion = _reader.ReadInt32();
    }
}
