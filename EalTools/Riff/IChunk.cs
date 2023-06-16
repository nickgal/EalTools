namespace EalTools.Riff;

public interface IChunk
{
    public FourCC ChunkId { get; set; }
    public int ChunkSize { get; set; }
    public void Initialize(byte[] data);
}
