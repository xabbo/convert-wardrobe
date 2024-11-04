
using System.Text.Json.Serialization;

[JsonSourceGenerationOptions(
    GenerationMode = JsonSourceGenerationMode.Default,
    WriteIndented = true,
    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
    PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase
)]
[JsonSerializable(typeof(FigureModel))]
[JsonSerializable(typeof(List<FigureModel>))]
public partial class JsonContext : JsonSerializerContext;
