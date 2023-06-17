namespace EalTools.Riff;

/// <summary>
/// Global Defraction Model
/// </summary>
public class GdfmChunk : Chunk
{
    public int MaxAttenuation { get; set; }
    public float LfRatio { get; set; }
    public int AngleMaxAttenuation { get; set; }

    public GdfmChunk()
    {
        ChunkId = FourCC.Gdfm;
    }

    public override void Initialize(byte[] data)
    {
        base.Initialize(data);
        MaxAttenuation = _reader.ReadInt32();
        LfRatio = _reader.ReadSingle();
        AngleMaxAttenuation = _reader.ReadInt32();
    }
}
