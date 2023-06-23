using System.Collections.Generic;

namespace EalTools.Riff
{
    public class NamsChunk : Chunk
    {
        public List<string> Names { get; set; } = new List<string>();

        public NamsChunk()
        {
            ChunkId = FourCC.Nams;
        }

        public override void Initialize(byte[] data)
        {
            base.Initialize(data);
            while (_reader.BaseStream.Position < _reader.BaseStream.Length)
            {
                Names.Add(_reader.ReadSzString(32));
            }
        }
    }
}
