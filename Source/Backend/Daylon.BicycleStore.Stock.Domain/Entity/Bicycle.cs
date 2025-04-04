using Daylon.BicycleStore.Stock.Domain.Entity.Enum;
using System.ComponentModel.DataAnnotations;

namespace Daylon.BicycleStore.Stock.Domain.Entity
{
    public class Bicycle
    {
        // BASIC PROPERTIES

        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 100 characters")]
        public string Name { get; set; } = string.Empty;

        [StringLength(500)]
        public string? Description { get; set; } = string.Empty;

        // TECHINICAL PROPERTIES

        [Required]
        public BrandEnum Brand { get; set; }

        [Required]
        public ModelEnum Model { get; set; }

        [Required]
        public ColorEnum Color { get; set; }

        // STOCK PROPERTIES

        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
        public double Price { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Quantity must be greater than or equal to 0")]
        public int Quantity { get; set; }

        public bool IsAvailable { get; set; }
    }
}
