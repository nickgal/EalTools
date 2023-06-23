namespace EalTools.Riff
{
    public class MajvChunk : Chunk
    {
        public int MajorVersion { get; set; }

        public MajvChunk()
        {
            ChunkId = FourCC.Majv;
        }

        public override void Initialize(byte[] data)
        {
            base.Initialize(data);
            MajorVersion = _reader.ReadInt32();
        }
    }
}
