using System.Text.Json;
using System.Text.Json.Serialization;
using FractalPainting.Application.Models;

namespace FractalPainting.Application;

internal sealed class FigureJsonConverter : JsonConverter<Figure>
{
    public override Figure? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }

    public override void Write(Utf8JsonWriter writer, Figure value, JsonSerializerOptions options)
    {
        if (value is Line line)
        {
            writer.WriteRawValue(JsonSerializer.Serialize(line));
            return;
        }

        if (value is Rectangle rect)
        {
            writer.WriteRawValue(JsonSerializer.Serialize(rect));
            return;
        }
    }
}