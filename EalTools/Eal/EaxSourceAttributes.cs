namespace EalTools.Eal;

public class EaxSourceAttributes
{
    // eaxAttributes
    public EaxBufferProperties EaxAttributes { get; set; }
    // ulInsideConeAngle
    public uint InsideConeAngle { get; set; }
    // ulOutsideConeAngle
    public uint OutsideConeAngle { get; set; }
    // lConeOutsideVolume
    public int ConeOutsideVolume { get; set; }
    // fConeXdir
    public float ConeXdir { get; set; }
    // fConeYdir
    public float ConeYdir { get; set; }
    // fConeZdir
    public float ConeZdir { get; set; }
    // fMinDistance
    public float MinDistance { get; set; }
    // fMaxDistance
    public float MaxDistance { get; set; }
    // lDupCount
    public int DupCount { get; set; }
    // lPriority
    public int Priority { get; set; }

    public static EaxSourceAttributes Parse(BinaryReader reader)
    {
        return new()
        {
            EaxAttributes = EaxBufferProperties.Parse(reader),
            InsideConeAngle = reader.ReadUInt32(),
            OutsideConeAngle = reader.ReadUInt32(),
            ConeOutsideVolume = reader.ReadInt32(),
            ConeXdir = reader.ReadSingle(),
            ConeYdir = reader.ReadSingle(),
            ConeZdir = reader.ReadSingle(),
            MinDistance = reader.ReadSingle(),
            MaxDistance = reader.ReadSingle(),
            DupCount = reader.ReadInt32(),
            Priority = reader.ReadInt32(),
        };
    }
}
