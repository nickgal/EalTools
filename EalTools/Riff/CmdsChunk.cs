namespace EalTools.Riff;

public class CmdsChunk : Chunk
{
    public CmdsChunk()
    {
        ChunkId = FourCC.Cmds;
    }

    public override void Initialize(byte[] data)
    {
        base.Initialize(data);
        // TODO: Parse contents
        //
        // fixed 260 bytes
        // starts with 00 0b
        // then 18 floats
        // then ...?
        //
        // Some unreal files have 260 zero bytes
    }
}
