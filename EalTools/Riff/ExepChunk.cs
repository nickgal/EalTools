namespace EalTools.Riff
{
    public class ExepChunk : Chunk
    {
        public ExepChunk()
        {
            ChunkId = FourCC.Exep;
        }

        public override void Initialize(byte[] data)
        {
            base.Initialize(data);
            // TODO: Parse contents
            //
            // fixed 260 bytes
            // starts with 00 0b
            // then 64 floats
            // then a6 7a
            //
            // Some unreal files have 260 zero bytes
        }
    }
}
