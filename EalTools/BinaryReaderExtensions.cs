using System.Text;

namespace EalTools;

public static class BinaryReaderExtensions
{
    public static string ReadSzString(this BinaryReader reader)
    {
        var result = new StringBuilder();
        char chr;

        while ((chr = reader.ReadChar()) != '\0')
        {
            result.Append(chr);
        }

        return result.ToString();
    }

    public static string ReadSzString(this BinaryReader reader, int count)
    {
        var bytes = reader.ReadBytes(count);
        return Encoding.ASCII.GetString(bytes.TakeWhile(b => b != 0).ToArray());
    }
}
