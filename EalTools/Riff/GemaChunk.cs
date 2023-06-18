namespace EalTools.Riff;

public class GemaChunk : Chunk
{
    public GemaChunk()
    {
        ChunkId = FourCC.Gema;
    }

    public override void Initialize(byte[] data)
    {
        base.Initialize(data);
        // TODO: Parse contents
    }
}
