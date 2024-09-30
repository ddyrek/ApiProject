using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;

namespace Groomer.Shared.Inext.Queries.DetailInextFullStateQuery
{
    public partial class InextFullStateDetailVm
    {
        public List<object> Errors { get; set; }
        public DateTimeOffset LastFullUpdateAt { get; set; }
        public List<Param> Params { get; set; }
    }

    public class Param
    {
        public string Code { get; set; }
        public bool Hidden { get; set; }
        public double? Max { get; set; }
        public double? Min { get; set; }
        public double? Value { get; set; }
        public bool Write { get; set; }
        public double? Zones { get; set; }
        public string ValueCode { get; set; }
        public string ValueLabel { get; set; }
        public ExtInfo ExtInfo { get; set; }
    }

    public class ExtInfo
    {
        public string Code { get; set; }
        public string Label { get; set; }
        public string Type { get; set; }
    }

    public class ValueElement
    {
        public string Code { get; set; }
        public List<Datum> Data { get; set; }
        public string Label { get; set; }
    }

    public class Datum
    {
        public double Start { get; set; }
        public double Stop { get; set; }
    }

    public class PurpleValue
    {
        public double Hour { get; set; }
        public double Minute { get; set; }
        public double WeekDay { get; set; }
        public bool WeekDayEnabled { get; set; }
    }

    public struct ValueUnion
    {
        public double? Double;
        public PurpleValue PurpleValue;
        public List<ValueElement> ValueElementArray;

        public static implicit operator ValueUnion(double Double) => new ValueUnion { Double = Double };
        public static implicit operator ValueUnion(PurpleValue PurpleValue) => new ValueUnion { PurpleValue = PurpleValue };
        public static implicit operator ValueUnion(List<ValueElement> ValueElementArray) => new ValueUnion { ValueElementArray = ValueElementArray };
    }
    public partial class InextFullStateDetailVm
    {
        public static InextFullStateDetailVm FromJson(string json) => JsonSerializer.Deserialize<InextFullStateDetailVm>(json, DetailInextFullStateQuery.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this InextFullStateDetailVm self) => JsonSerializer.Serialize(self, DetailInextFullStateQuery.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerOptions Settings = new(JsonSerializerDefaults.General)
        {
            Converters =
            {
                ValueUnionConverter.Singleton,
                new DateOnlyConverter(),
                new TimeOnlyConverter(),
                IsoDateTimeOffsetConverter.Singleton
            },
        };
    }

    internal class ValueUnionConverter : JsonConverter<ValueUnion>
    {
        public override bool CanConvert(Type t) => t == typeof(ValueUnion);

        public override ValueUnion Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            switch (reader.TokenType)
            {
                case JsonTokenType.Number:
                    var doubleValue = reader.GetDouble();
                    return new ValueUnion { Double = doubleValue };
                case JsonTokenType.StartObject:
                    var objectValue = JsonSerializer.Deserialize<PurpleValue>(ref reader, options);
                    return new ValueUnion { PurpleValue = objectValue };
                case JsonTokenType.StartArray:
                    var arrayValue = JsonSerializer.Deserialize<List<ValueElement>>(ref reader, options);
                    return new ValueUnion { ValueElementArray = arrayValue };
            }
            throw new Exception("Cannot unmarshal type ValueUnion");
        }

        public override void Write(Utf8JsonWriter writer, ValueUnion value, JsonSerializerOptions options)
        {
            if (value.Double != null)
            {
                JsonSerializer.Serialize(writer, value.Double.Value, options);
                return;
            }
            if (value.ValueElementArray != null)
            {
                JsonSerializer.Serialize(writer, value.ValueElementArray, options);
                return;
            }
            if (value.PurpleValue != null)
            {
                JsonSerializer.Serialize(writer, value.PurpleValue, options);
                return;
            }
            throw new Exception("Cannot marshal type ValueUnion");
        }

        public static readonly ValueUnionConverter Singleton = new ValueUnionConverter();
    }

    public class DateOnlyConverter : JsonConverter<DateOnly>
    {
        private readonly string serializationFormat;
        public DateOnlyConverter() : this(null) { }

        public DateOnlyConverter(string? serializationFormat)
        {
            this.serializationFormat = serializationFormat ?? "yyyy-MM-dd";
        }

        public override DateOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetString();
            return DateOnly.Parse(value!);
        }

        public override void Write(Utf8JsonWriter writer, DateOnly value, JsonSerializerOptions options)
            => writer.WriteStringValue(value.ToString(serializationFormat));
    }

    public class TimeOnlyConverter : JsonConverter<TimeOnly>
    {
        private readonly string serializationFormat;

        public TimeOnlyConverter() : this(null) { }

        public TimeOnlyConverter(string? serializationFormat)
        {
            this.serializationFormat = serializationFormat ?? "HH:mm:ss.fff";
        }

        public override TimeOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetString();
            return TimeOnly.Parse(value!);
        }

        public override void Write(Utf8JsonWriter writer, TimeOnly value, JsonSerializerOptions options)
            => writer.WriteStringValue(value.ToString(serializationFormat));
    }

    internal class IsoDateTimeOffsetConverter : JsonConverter<DateTimeOffset>
    {
        public override bool CanConvert(Type t) => t == typeof(DateTimeOffset);

        private const string DefaultDateTimeFormat = "yyyy'-'MM'-'dd'T'HH':'mm':'ss.FFFFFFFK";

        private DateTimeStyles _dateTimeStyles = DateTimeStyles.RoundtripKind;
        private string? _dateTimeFormat;
        private CultureInfo? _culture;

        public DateTimeStyles DateTimeStyles
        {
            get => _dateTimeStyles;
            set => _dateTimeStyles = value;
        }

        public string? DateTimeFormat
        {
            get => _dateTimeFormat ?? string.Empty;
            set => _dateTimeFormat = (string.IsNullOrEmpty(value)) ? null : value;
        }

        public CultureInfo Culture
        {
            get => _culture ?? CultureInfo.CurrentCulture;
            set => _culture = value;
        }

        public override void Write(Utf8JsonWriter writer, DateTimeOffset value, JsonSerializerOptions options)
        {
            string text;


            if ((_dateTimeStyles & DateTimeStyles.AdjustToUniversal) == DateTimeStyles.AdjustToUniversal
                || (_dateTimeStyles & DateTimeStyles.AssumeUniversal) == DateTimeStyles.AssumeUniversal)
            {
                value = value.ToUniversalTime();
            }

            text = value.ToString(_dateTimeFormat ?? DefaultDateTimeFormat, Culture);

            writer.WriteStringValue(text);
        }

        public override DateTimeOffset Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string? dateText = reader.GetString();

            if (string.IsNullOrEmpty(dateText) == false)
            {
                if (!string.IsNullOrEmpty(_dateTimeFormat))
                {
                    return DateTimeOffset.ParseExact(dateText, _dateTimeFormat, Culture, _dateTimeStyles);
                }
                else
                {
                    return DateTimeOffset.Parse(dateText, Culture, _dateTimeStyles);
                }
            }
            else
            {
                return default(DateTimeOffset);
            }
        }


        public static readonly IsoDateTimeOffsetConverter Singleton = new IsoDateTimeOffsetConverter();
    }
}
#pragma warning restore CS8618
#pragma warning restore CS8601
#pragma warning restore CS8603

