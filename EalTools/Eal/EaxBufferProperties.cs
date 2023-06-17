namespace EalTools.Eal;

public class EaxBufferProperties
{
    // lDirect
    // direct path level
    public int DirectPathLevel { get; set; }

    // lDirectHF
    // direct path level at high frequencies
    public int DirectPathHfLevel { get; set; }

    // lRoom
    // room effect level
    public int RoomPathLevel { get; set; }

    // lRoomHF
    // room effect level at high frequencies
    public int RoomPathHfLevel { get; set; }

    // flRoomRolloffFactor
    // like DS3D flRolloffFactor but for room effect
    public float RoomRolloffFactor { get; set; }

    // lObstruction
    // main obstruction control (attenuation at high frequencies)
    public int Obstruction { get; set; }

    // flObstructionLFRatio
    // obstruction low-frequency level re. main control
    public float ObstructionLfRatio { get; set; }

    // lOcclusion
    // main occlusion control (attenuation at high frequencies)
    public int Occlusion { get; set; }

    // flOcclusionLFRatio
    // occlusion low-frequency level re. main control
    public float ObstacleLfRatio { get; set; }

    // flOcclusionRoomRatio
    // occlusion room effect level re. main control
    public float ObstacleRoomRatio { get; set; }

    // lOutsideVolumeHF
    // outside sound cone level at high frequencies
    public int OutsideVolumeHf { get; set; }

    // flAirAbsorptionFactor
    // multiplies DSPROPERTY_EAXLISTENER_AIRABSORPTIONHF
    public float AirAbsorptionFactor { get; set; }

    // dwFlags
    // modifies the behavior of properties
    public EaxBufferFlags Flags { get; set; }

    public static EaxBufferProperties Parse(BinaryReader reader)
    {
        return new()
        {
            DirectPathLevel = reader.ReadInt32(),
            DirectPathHfLevel = reader.ReadInt32(),
            RoomPathLevel = reader.ReadInt32(),
            RoomPathHfLevel = reader.ReadInt32(),
            RoomRolloffFactor = reader.ReadSingle(),
            Obstruction = reader.ReadInt32(),
            ObstructionLfRatio = reader.ReadSingle(),
            Occlusion = reader.ReadInt32(),
            ObstacleLfRatio = reader.ReadSingle(),
            ObstacleRoomRatio = reader.ReadSingle(),
            OutsideVolumeHf = reader.ReadInt32(),
            AirAbsorptionFactor = reader.ReadSingle(),
            Flags = (EaxBufferFlags)reader.ReadInt32(),
        };
    }
}
