using EalTools.Eal;

namespace EalTools.Riff;
/// <summary>
/// DefaultEnvironment
/// </summary>
public class DenvChunk : Chunk
{
    public EaxListenerProperties ListenerProperties { get; set; }

    public DenvChunk()
    {
        ChunkId = FourCC.Denv;
    }

    public override void Initialize(byte[] data)
    {
        base.Initialize(data);
        ListenerProperties = EaxListenerProperties.Parse(_reader);
    }
}
