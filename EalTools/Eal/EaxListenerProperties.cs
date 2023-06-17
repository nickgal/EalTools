namespace EalTools.Eal;

/// <summary>
/// _EAXLISTENERPROPERTIES
///  - all levels are hundredths of decibels
///  - all times are in seconds
///  - the reference for high frequency controls is 5 kHz
/// </summary>
public class EaxListenerProperties
{
    public int Room;                    // room effect level at low frequencies
    public int RoomHF;                  // room effect high-frequency level re. low frequency level
    public float RoomRolloffFactor;     // like DS3D flRolloffFactor but for room effect
    public float DecayTime;             // reverberation decay time at low frequencies
    public float DecayHFRatio;          // high-frequency to low-frequency decay time ratio
    public int Reflections;             // early reflections level relative to room effect
    public float ReflectionsDelay;      // initial reflection delay time
    public int Reverb;                  // late reverberation level relative to room effect
    public float ReverbDelay;           // late reverberation delay time relative to initial reflection
    public EaxEnvironment Environment;  // sets all listener properties
    public float EnvironmentSize;       // environment size in meters
    public float EnvironmentDiffusion;  // environment diffusion
    public float AirAbsorptionHF;       // change in level per meter at 5 kHz
    public EaxListenerFlags Flags;      // modifies the behavior of properties

    public static EaxListenerProperties Parse(BinaryReader reader)
    {
        return new()
        {
            Room = reader.ReadInt32(),
            RoomHF = reader.ReadInt32(),
            RoomRolloffFactor = reader.ReadSingle(),
            DecayTime = reader.ReadSingle(),
            DecayHFRatio = reader.ReadSingle(),
            Reflections = reader.ReadInt32(),
            ReflectionsDelay = reader.ReadSingle(),
            Reverb = reader.ReadInt32(),
            ReverbDelay = reader.ReadSingle(),
            Environment = (EaxEnvironment) reader.ReadUInt32(),
            EnvironmentSize = reader.ReadSingle(),
            EnvironmentDiffusion = reader.ReadSingle(),
            AirAbsorptionHF = reader.ReadSingle(),
            Flags = (EaxListenerFlags) reader.ReadUInt32(),
        };
    }
}
