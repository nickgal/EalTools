using EalTools.Eal;

namespace EalTools.Riff;

public class LisaChunk : Chunk
{
    public EaxListenerAttributes ListenerAttributes { get; set; }

    public LisaChunk()
    {
        ChunkId = FourCC.Lisa;
    }

    public override void Initialize(byte[] data)
    {
        base.Initialize(data);
        ListenerAttributes = EaxListenerAttributes.Parse(_reader);
    }
}
