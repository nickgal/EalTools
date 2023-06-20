using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;

using EalTools.Riff;

namespace EalTools.Tui;
public class ChunkTypeResolver : DefaultJsonTypeInfoResolver
{
    public override JsonTypeInfo GetTypeInfo(Type type, JsonSerializerOptions options)
    {
        JsonTypeInfo jsonTypeInfo = base.GetTypeInfo(type, options);

        Type chunkType = typeof(IChunk);
        if (jsonTypeInfo.Type == chunkType)
        {
            jsonTypeInfo.PolymorphismOptions = new JsonPolymorphismOptions
            {
                TypeDiscriminatorPropertyName = "$chunk-type",
                IgnoreUnrecognizedTypeDiscriminators = true,
                UnknownDerivedTypeHandling = JsonUnknownDerivedTypeHandling.FailSerialization,
                DerivedTypes =
                {
                    // new JsonDerivedType(typeof(Chunk)),
                    new JsonDerivedType(typeof(CmdsChunk)),
                    new JsonDerivedType(typeof(DenvChunk)),
                    new JsonDerivedType(typeof(DfilChunk)),
                    new JsonDerivedType(typeof(DmatChunk)),
                    new JsonDerivedType(typeof(DsrcChunk)),
                    new JsonDerivedType(typeof(ExepChunk)),
                    new JsonDerivedType(typeof(FilsChunk)),
                    new JsonDerivedType(typeof(GdfmChunk)),
                    new JsonDerivedType(typeof(GemaChunk)),
                    new JsonDerivedType(typeof(LisaChunk)),
                    new JsonDerivedType(typeof(LispChunk)),
                    new JsonDerivedType(typeof(ListChunk)),
                    new JsonDerivedType(typeof(MajvChunk)),
                    new JsonDerivedType(typeof(MataChunk)),
                    new JsonDerivedType(typeof(MinvChunk)),
                    new JsonDerivedType(typeof(NamsChunk)),
                    new JsonDerivedType(typeof(NumChunk)),
                    new JsonDerivedType(typeof(RiffChunk)),
                    new JsonDerivedType(typeof(SrcaChunk)),
                    new JsonDerivedType(typeof(UnknownChunk)),
                }
            };
        }

        return jsonTypeInfo;
    }
}
