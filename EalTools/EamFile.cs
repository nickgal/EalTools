using System.IO;

using EalTools.Riff;

namespace EalTools
{
    public class EamFile : RiffFile
    {
        protected override FourCC FormType => FourCC.Eam;

        public EamFile(string filePath) : base(filePath)
        {
        }

        public EamFile(Stream stream) : base(stream)
        {
        }

        public override bool Initialize()
        {
            if (!base.Initialize())
            {
                return false;
            }

            Data = new EamData(RootChunk);

            return true;
        }
    }
}
