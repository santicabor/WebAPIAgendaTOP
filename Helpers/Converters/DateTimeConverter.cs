using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace WebAPIAgendaTOP.Helpers.Converters
{
    public class DateTimeConverter : JsonConverter<DateTime>
    {        
            public override DateTime Read(
                ref Utf8JsonReader reader,
                Type typeToConvert,
                JsonSerializerOptions options) =>
                    DateTime.ParseExact(reader.GetString(),
                        "dd/MM/yyyy hh:mm", CultureInfo.InvariantCulture);

            public override void Write(
                Utf8JsonWriter writer,
                DateTime dateTimeValue,
                JsonSerializerOptions options) =>
                    writer.WriteStringValue(dateTimeValue.ToString(
                        "dd/MM/yyyy hh:mm", CultureInfo.InvariantCulture));
    }
}
