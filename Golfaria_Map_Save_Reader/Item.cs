using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Golfaria_Map_Save_Reader
{
    public class Item
    {
        public string room { get; set; }
        public string type { get; set; }
        public int x { get; set; }
        public int y { get; set; }

        [JsonConverter(typeof(JsonStringConverter))]
        public string save_value { get; set; }
        public bool collected { get; set; } = false;
    }
    public class JsonStringConverter : JsonConverter<string>
    {
        public override string Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
            return reader.TokenType switch
            {
                JsonTokenType.String => reader.GetString(),
                JsonTokenType.Number => reader.GetInt64().ToString(),
                _ => throw new JsonException()
            };
        }

        public override void Write(Utf8JsonWriter writer, string value, JsonSerializerOptions options) {
            writer.WriteStringValue(value);
        }
    }
}