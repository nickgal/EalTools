using System.IO;

namespace EalTools.Riff
{
    public static class RiffFileFactory
    {
        public static RiffFile? GetRiffFile(BinaryReader reader)
        {
            var chunk = ChunkFactory.GetChunk(reader);
            if (!(chunk is ListChunk listChunk))
            {
                return null;
            }

            reader.BaseStream.Position = 0;

            return listChunk.FormType switch
            {
                FourCC.Eal => new EalFile(reader.BaseStream),
                FourCC.Eam => new EamFile(reader.BaseStream),
                _ => null,
            };
        }
    }
}
