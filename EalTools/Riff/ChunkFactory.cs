namespace EalTools.Riff;

public static class ChunkFactory
{
    public static IChunk GetChunk(BinaryReader reader)
    {
        var chunkType = (FourCC)reader.ReadUInt32();
        var chunkSize = reader.ReadInt32();
        var chunkData = reader.ReadBytes(chunkSize);
        var chunk = GetChunkFromType(chunkType);

        chunk.Initialize(chunkData);

        return chunk;
    }

    private static IChunk GetChunkFromType(FourCC chunkType)
    {
        return chunkType switch
        {
            FourCC.Riff => new RiffChunk(),
            FourCC.List => new ListChunk(),
            FourCC.Majv => new MajChunk(),
            _ => new UnknownChunk(),
        };
    }
}
