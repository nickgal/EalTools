using System.IO;

using EalTools.Riff;

namespace EalTools
{
    public class EalFile : RiffFile
    {
        protected override FourCC FormType => FourCC.Eal;

        public EalFile(string filePath) : base(filePath)
        {
        }

        public EalFile(Stream stream) : base(stream)
        {
        }

        public override bool Initialize()
        {
            if (!base.Initialize())
            {
                return false;
            }

            Data = new EalData(RootChunk);

            return true;
        }
    }
}
