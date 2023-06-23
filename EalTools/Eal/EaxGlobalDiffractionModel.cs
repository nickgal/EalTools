using System.IO;

namespace EalTools.Eal
{
    public class EaxGlobalDiffractionModel
    {
        public int MaxAttenuation { get; set; }
        public float LfRatio { get; set; }
        public int AngleMaxAttenuation { get; set; }

        public static EaxGlobalDiffractionModel Parse(BinaryReader reader)
        {
            return new EaxGlobalDiffractionModel
            {
                MaxAttenuation = reader.ReadInt32(),
                LfRatio = reader.ReadSingle(),
                AngleMaxAttenuation = reader.ReadInt32(),
            };
        }
    }
}
