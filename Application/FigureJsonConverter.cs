using System.Text.Json;
using System.Text.Json.Serialization;
using di.Application.Models;

namespace di.Application;

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
            writer.WriteRawValue(JsonSerializer.Serialize(line, new JsonSerializerOptions
            {
                
            }));
            return;
        }

        if (value is Rectangle rect)
        {
            writer.WriteRawValue(JsonSerializer.Serialize(rect));
            return;
        }
    }
}