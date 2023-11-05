using System.Text.Json;
using System.Text.Json.Serialization;

namespace WebAPIEventService.Infra.Tools
{
    public class TimeOnlyJsonConverter : JsonConverter<System.TimeOnly>
    {
        public override System.TimeOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.String)
            {
                if (System.TimeOnly.TryParse(reader.GetString(), out System.TimeOnly time))
                {
                    return time;
                }
            }

            throw new JsonException("Invalid time format");
        }

        public override void Write(Utf8JsonWriter writer, System.TimeOnly value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }
}
