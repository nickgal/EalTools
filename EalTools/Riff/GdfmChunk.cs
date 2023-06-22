using EalTools.Eal;

namespace EalTools.Riff;
/// <summary>
/// Global Defraction Model
/// </summary>
public class GdfmChunk : Chunk
{
    public EaxGlobalDiffractionModel DiffractionModel { get; set; }

    public GdfmChunk()
    {
        ChunkId = FourCC.Gdfm;
    }

    public override void Initialize(byte[] data)
    {
        base.Initialize(data);
        DiffractionModel = EaxGlobalDiffractionModel.Parse(_reader);
    }
}
