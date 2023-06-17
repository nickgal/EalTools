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
            FourCC.Majv => new MajvChunk(),
            FourCC.Minv => new MinvChunk(),
            // FourCC.Exep => new ExepChunk(),
            // FourCC.Cmds => new CmdsChunk(),
            // FourCC.Gdfm => new GdfmChunk(),
            FourCC.Lisa => new LisaChunk(),
            FourCC.Denv => new DenvChunk(),
            FourCC.Dsrc => new DsrcChunk(),
            FourCC.Dfil => new DfilChunk(),
            FourCC.Dmat => new DmatChunk(),
            FourCC.Num => new NumChunk(),
            FourCC.Nams => new NamsChunk(),
            FourCC.Fils => new FilsChunk(),
            FourCC.Lisp => new LispChunk(),
            FourCC.Srca => new SrcaChunk(),
            FourCC.Mata => new MataChunk(),
            // FourCC.Gema => new GemaChunk(),

            _ => new UnknownChunk(),
        };
    }
}
