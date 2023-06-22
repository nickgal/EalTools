using EalTools.Eal;

namespace EalTools.Riff;

public class GemaChunk : Chunk
{
    public List<EalGeometryAttributes> GeometryAttributes { get; set; } = new List<EalGeometryAttributes>();
    public GemaChunk()
    {
        ChunkId = FourCC.Gema;
    }

    public override void Initialize(byte[] data)
    {
        base.Initialize(data);
        // TODO:
        // while (_reader.BaseStream.Position < _reader.BaseStream.Length)
        // {
        //     GeometryAttributes.Add(EalGeometryAttributes.Parse(_reader));
        // }
    }
}
