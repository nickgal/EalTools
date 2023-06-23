using System.Collections.Generic;

using EalTools.Eal;

namespace EalTools.Riff
{
    public class LispChunk : Chunk
    {
        public List<EaxListenerProperties> ListenerProperties { get; set; } = new List<EaxListenerProperties>();

        public LispChunk()
        {
            ChunkId = FourCC.Lisp;
        }

        public override void Initialize(byte[] data)
        {
            base.Initialize(data);
            while (_reader.BaseStream.Position < _reader.BaseStream.Length)
            {
                ListenerProperties.Add(EaxListenerProperties.Parse(_reader));
            }
        }
    }
}
