using EalTools.Eal;

namespace EalTools.Riff
{
    /// <summary>
    /// Default Obstacle
    /// </summary>
    public class DmatChunk : Chunk
    {
        public EaxMaterialAttributes MaterialAttributes { get; set; }

        public DmatChunk()
        {
            ChunkId = FourCC.Dmat;
        }

        public override void Initialize(byte[] data)
        {
            base.Initialize(data);
            MaterialAttributes = EaxMaterialAttributes.Parse(_reader);
        }
    }
}
