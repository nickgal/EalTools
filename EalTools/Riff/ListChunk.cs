namespace EalTools.Riff;

public class ListChunk : Chunk
{
    public FourCC FormType { get; set; }
    public List<IChunk> SubChunks { get; set; } = new List<IChunk>();

    public ListChunk()
    {
        ChunkId = FourCC.List;
    }

    public override void Initialize(byte[] data)
    {
        base.Initialize(data);
        FormType = (FourCC)_reader.ReadUInt32();

        while (_reader.BaseStream.Position < _reader.BaseStream.Length)
        {
            var subChunk = ChunkFactory.GetChunk(_reader);
            SubChunks.Add(subChunk);
        }
    }
}
