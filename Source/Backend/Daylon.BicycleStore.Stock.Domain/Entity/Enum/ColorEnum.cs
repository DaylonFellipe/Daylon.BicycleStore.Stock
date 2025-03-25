using System.Text.Json.Serialization;

namespace Daylon.BicycleStore.Stock.Domain.Entity.Enum
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ColorEnum
    {
        Indefinite = 0,
        Black = 1,
        White = 2,
        Red = 3,
        Blue = 4,
        Green = 5,
        Yellow = 6,
        Orange = 7,
        Purple = 8,
        Gray = 9
    }
}
