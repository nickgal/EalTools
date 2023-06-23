using System.IO;

namespace EalTools.Riff
{
    public abstract class Chunk : IChunk
    {
        public FourCC ChunkId { get; set; }
        public int ChunkSize { get; set; }

        protected BinaryReader _reader;

        public virtual void Initialize(byte[] data)
        {
            ChunkSize = data.Length;
            _reader = new BinaryReader(new MemoryStream(data));
        }
    }
}
