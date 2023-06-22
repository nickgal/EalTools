using EalTools.Eal;

namespace EalTools.Riff;
/// <summary>
/// Default Source
/// </summary>
public class DsrcChunk : Chunk
{
    public EaxSourceAttributes SourceAttributes { get; set; }

    public DsrcChunk()
    {
        ChunkId = FourCC.Dsrc;
    }

    public override void Initialize(byte[] data)
    {
        base.Initialize(data);
        SourceAttributes = EaxSourceAttributes.Parse(_reader);
    }
}
