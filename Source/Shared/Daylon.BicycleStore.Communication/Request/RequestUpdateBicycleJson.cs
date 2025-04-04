﻿using Daylon.BicycleStore.Stock.Domain.Entity.Enum;

namespace Daylon.BicycleStore.Communication.Request
{
    public class RequestUpdateBicycleJson
    {
        // Basic Properties
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; } 

        // Technical Properties
        public BrandEnum Brand { get; set; }
        public ModelEnum Model { get; set; }
        public ColorEnum Color { get; set; }

        // Stock Properties
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
}
