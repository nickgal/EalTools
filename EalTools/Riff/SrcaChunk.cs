using EalTools.Eal;

namespace EalTools.Riff;

public class SrcaChunk : Chunk
{
    public List<EaxSourceAttributes> SourceAttributes { get; set; } = new List<EaxSourceAttributes>();

    public SrcaChunk()
    {
        ChunkId = FourCC.Srca;
    }

    public override void Initialize(byte[] data)
    {
        base.Initialize(data);
        while (_reader.BaseStream.Position < _reader.BaseStream.Length)
        {
            SourceAttributes.Add(EaxSourceAttributes.Parse(_reader));
        }
    }
}
