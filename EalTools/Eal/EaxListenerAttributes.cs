namespace EalTools.Eal;

public class EaxListenerAttributes
{
    public float DistanceFactor { get; set; }
    public float RolloffFactor { get; set; }
    public float DopplerFactor { get; set; }

    public static EaxListenerAttributes Parse(BinaryReader reader)
    {
        return new()
        {
            DistanceFactor = reader.ReadSingle(),
            RolloffFactor = reader.ReadSingle(),
            DopplerFactor = reader.ReadSingle(),
        };
    }
}
