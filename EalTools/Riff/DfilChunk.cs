namespace EalTools.Riff
{
    public class DfilChunk : Chunk
    {
        public string Filepath { get; set; }

        public DfilChunk()
        {
            ChunkId = FourCC.Dfil;
        }

        public override void Initialize(byte[] data)
        {
            base.Initialize(data);
            Filepath = _reader.ReadSzString(260);
        }
    }
}
