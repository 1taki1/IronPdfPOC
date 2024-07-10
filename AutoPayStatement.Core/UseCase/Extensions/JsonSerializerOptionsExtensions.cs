using System.Text.Json;
using System.Text.Json.Serialization;

namespace AutoPayStatement.Core.UseCase.Extensions;

public static class JsonSerializerOptionsExtension
{
    public static readonly JsonSerializerOptions Default = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        WriteIndented = true,
        Converters = { new JsonStringEnumConverter() }
    };
}
