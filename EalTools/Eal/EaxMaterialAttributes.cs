namespace EalTools.Eal;

public class EaxMaterialAttributes
{
    public int Level;
    public float LfRatio;
    public float RoomRatio;
    public EaxMaterialFlags Flags;

    public static EaxMaterialAttributes Parse(BinaryReader reader)
    {
        return new()
        {
            Level = reader.ReadInt32(),
            LfRatio = reader.ReadSingle(),
            RoomRatio = reader.ReadSingle(),
            Flags = (EaxMaterialFlags) reader.ReadInt32(),
        };
    }
}
