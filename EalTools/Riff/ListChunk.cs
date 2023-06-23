using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace EalTools.Riff
{
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

        public IEnumerable<T> FindSubChunks<T>() where T : IChunk
        {
            return SubChunks?.OfType<T>() ?? Enumerable.Empty<T>();
        }

        public T? FindSubChunk<T>() where T : class, IChunk
        {
            return FindSubChunks<T>().FirstOrDefault();
        }

        public bool TryFindSubChunk<T>([NotNullWhen(returnValue: true)] out T subChunk) where T : class, IChunk
        {
            subChunk = FindSubChunk<T>()!;
            return subChunk != null;
        }

        public ListChunk? FindListOfForm(FourCC formType)
        {
            return FindSubChunks<ListChunk>().SingleOrDefault(c => c.FormType == formType);
        }

        public bool TryFindListOfForm(FourCC formType, [NotNullWhen(returnValue: true)] out ListChunk listChunk)
        {
            listChunk = FindListOfForm(formType)!;
            return listChunk != null;
        }
    }
}
