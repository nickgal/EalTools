namespace EalTools.Riff
{
    /// <summary>
    /// Execute Project
    /// </summary>
    public class ExepChunk : Chunk
    {
        public string Executable { get; set; }

        public ExepChunk()
        {
            ChunkId = FourCC.Exep;
        }

        public override void Initialize(byte[] data)
        {
            base.Initialize(data);
            Executable = _reader.ReadSzString(260);
        }
    }
}
