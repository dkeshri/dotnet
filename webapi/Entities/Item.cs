using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Webapi.Entities
{
    public record Item {
        public Guid Id { get; init; }
        public string Name { get; init; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; init; }

        public DateTimeOffset CreatedDate { get; init; }
    }
    
}