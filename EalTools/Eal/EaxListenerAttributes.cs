namespace EalTools.Eal;

public class EaxListenerAttributes
{
    public float DistanceFactor;
    public float RolloffFactor;
    public float DopplerFactor;

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
