using System.IO;

using EalTools.Riff;

namespace EalTools
{
    public abstract class RiffFile
    {
        public RiffData? Data { get; set; }
        public RiffChunk RootChunk = new RiffChunk();
        protected virtual FourCC FormType => FourCC.Unknown;
        protected readonly BinaryReader _reader;

        public RiffFile(string filePath)
        {
            var stream = File.Open(filePath, FileMode.Open);
            _reader = new BinaryReader(stream);
        }

        public RiffFile(Stream stream)
        {
            _reader = new BinaryReader(stream);
        }

        public virtual bool Initialize()
        {
            var chunk = ChunkFactory.GetChunk(_reader);
            if (!(chunk is RiffChunk riffChunk && riffChunk.FormType == FormType))
            {
                return false;
            }

            RootChunk = riffChunk;

            return true;
        }
    }
}
