using Daylon.BicycleStore.Stock.Domain.Entity.Enum;

namespace Daylon.BicycleStore.Stock.Application.DTO.BicycleDTO
{
    public class BicycleDTO
    {
        // Basic Properties

        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;

        // Technical Properties
        public BrandEnum Brand { get; set; }
        public ModelEnum Model { get; set; }
        public ColorEnum Color { get; set; }

        // Stock Properties
        public double Price { get; set; }
    }
}
