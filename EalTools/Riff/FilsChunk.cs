using System.Collections.Generic;

namespace EalTools.Riff
{
    public class FilsChunk : Chunk
    {
        public List<string> Filepaths { get; set; } = new List<string>();

        public FilsChunk()
        {
            ChunkId = FourCC.Fils;
        }

        public override void Initialize(byte[] data)
        {
            base.Initialize(data);
            while (_reader.BaseStream.Position < _reader.BaseStream.Length)
            {
                Filepaths.Add(_reader.ReadSzString(260));
            }
        }
    }
}
