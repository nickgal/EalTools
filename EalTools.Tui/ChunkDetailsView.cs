using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

using EalTools.Riff;

using Terminal.Gui;

using Attribute = Terminal.Gui.Attribute;
using Rune = System.Rune;

namespace EalTools.Tui;

class ChunkDetailsView : TextView
{
    private IChunk _chunk;
    private readonly StringBuilder _stringBuilder;
    private readonly JsonSerializerOptions _jsonSerializerOptions;

    public ChunkDetailsView()
    {
        Visible = true;
        ReadOnly = true;
        WordWrap = true;
        _stringBuilder = new StringBuilder();
        _jsonSerializerOptions = new JsonSerializerOptions()
        {
            TypeInfoResolver = new ChunkTypeResolver(),
            Converters =
            {
                new JsonStringEnumConverter(JsonNamingPolicy.CamelCase)
            },
            WriteIndented = true
        };
        _chunk = new UnknownChunk();
    }

    public override Attribute GetNormalColor()
    {
        return ColorScheme.Normal;
    }

    protected override void SetReadOnlyColor(List<Rune> line, int idx)
    {
        Driver.SetAttribute(ColorScheme.Normal);
    }


    public IChunk Chunk
    {
        get => _chunk;
        set
        {
            _chunk = value;
            _stringBuilder.Clear();

            if (_chunk is not RiffChunk && _chunk is not UnknownChunk)
            {
                _stringBuilder.AppendLine(JsonSerializer.Serialize(_chunk, _jsonSerializerOptions));
            }

            Text = _stringBuilder.ToString();
        }
    }
}