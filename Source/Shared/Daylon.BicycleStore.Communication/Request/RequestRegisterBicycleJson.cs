using Daylon.BicycleStore.Stock.Domain.Entity.Enum;

namespace Daylon.BicycleStore.Communication.Request
{
    public class RequestRegisterBicycleJson
    {
        // BASIC PROPERTIES
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;

        // TECHNICAL PROPERTIES
        public BrandEnum Brand { get; set; }
        public ModelEnum Model { get; set; }
        public ColorEnum Color { get; set; }

        // STOCK PROPERTIES
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
}
