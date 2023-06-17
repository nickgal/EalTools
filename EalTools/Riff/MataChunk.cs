using EalTools.Eal;

namespace EalTools.Riff;

public class MataChunk : Chunk
{
    public List<EaxMaterialAttributes> MaterialAttributes { get; set; } = new List<EaxMaterialAttributes>();

    public MataChunk()
    {
        ChunkId = FourCC.Mata;
    }

    public override void Initialize(byte[] data)
    {
        base.Initialize(data);
        while (_reader.BaseStream.Position < _reader.BaseStream.Length)
        {
            MaterialAttributes.Add(EaxMaterialAttributes.Parse(_reader));
        }
    }
}
