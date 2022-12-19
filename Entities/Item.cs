using System;

namespace Catalog.Entities
{
    // Record use for immutable objects 
    // With-expression support 
    // value based equality support
    public record Item
    {
        public Guid Id { get; init; }    //Init only properly // set value on initialisation only

        public string Name { get; init; }

        public decimal Price { get; init; }

        public DateTimeOffset CreatedDate { get; init; }
    }
}