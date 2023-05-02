using System;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace gamezone_api.Helpers
{
	public class DateTimeConverter : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            Debug.Assert(typeToConvert == typeof(DateTime));
            return DateTime.Parse(reader.GetString());
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            var dateTime = value.Kind == DateTimeKind.Local ? value.ToUniversalTime() : value;
            writer.WriteStringValue(dateTime.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ssZ"));
        }
    }
}

