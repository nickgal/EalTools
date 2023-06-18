namespace EalTools.Eal;

/// <summary>
/// _EAXLISTENERPROPERTIES
///  - all levels are hundredths of decibels
///  - all times are in seconds
///  - the reference for high frequency controls is 5 kHz
/// </summary>
public class EaxListenerProperties
{
    public int Room { get; set; }                    // room effect level at low frequencies
    public int RoomHF { get; set; }                  // room effect high-frequency level re. low frequency level
    public float RoomRolloffFactor { get; set; }     // like DS3D flRolloffFactor but for room effect
    public float DecayTime { get; set; }             // reverberation decay time at low frequencies
    public float DecayHFRatio { get; set; }          // high-frequency to low-frequency decay time ratio
    public int Reflections { get; set; }             // early reflections level relative to room effect
    public float ReflectionsDelay { get; set; }      // initial reflection delay time
    public int Reverb { get; set; }                  // late reverberation level relative to room effect
    public float ReverbDelay { get; set; }           // late reverberation delay time relative to initial reflection
    public EaxEnvironment Environment { get; set; }  // sets all listener properties
    public float EnvironmentSize { get; set; }       // environment size in meters
    public float EnvironmentDiffusion { get; set; }  // environment diffusion
    public float AirAbsorptionHF { get; set; }       // change in level per meter at 5 kHz
    public EaxListenerFlags Flags { get; set; }      // modifies the behavior of properties

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
