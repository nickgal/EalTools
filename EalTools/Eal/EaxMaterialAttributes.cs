using System.IO;

namespace EalTools.Eal
{
    public class EaxMaterialAttributes
    {
        public int Level { get; set; }
        public float LfRatio { get; set; }
        public float RoomRatio { get; set; }
        public EaxMaterialFlags Flags { get; set; }

        public static EaxMaterialAttributes Parse(BinaryReader reader)
        {
            return new EaxMaterialAttributes
            {
                Level = reader.ReadInt32(),
                LfRatio = reader.ReadSingle(),
                RoomRatio = reader.ReadSingle(),
                Flags = (EaxMaterialFlags)reader.ReadInt32(),
            };
        }
    }
}
