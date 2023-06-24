namespace EalTools.Riff
{
    /// <summary>
    /// Commands
    /// </summary>
    public class CmdsChunk : Chunk
    {
        public string Commands { get; set; }

        public CmdsChunk()
        {
            ChunkId = FourCC.Cmds;
        }

        public override void Initialize(byte[] data)
        {
            base.Initialize(data);
            Commands = _reader.ReadSzString(260);
        }
    }
}
