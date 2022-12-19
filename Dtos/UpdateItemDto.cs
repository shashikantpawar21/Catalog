using System;
using System.ComponentModel.DataAnnotations;

namespace Catalog.Dtos
{
    public record UpdateItemDto
    {

        [Required]
        public string Name { get; init; }

        [Required]
        [Range(1, 100)]
        public decimal Price { get; init; }
    }
}