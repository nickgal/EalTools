namespace EalTools.Riff;

public class NumChunk : Chunk
{
    public int Number { get; set; }

    public NumChunk()
    {
        ChunkId = FourCC.Num;
    }

    public override void Initialize(byte[] data)
    {
        base.Initialize(data);
        Number = _reader.ReadInt32();
    }
}
