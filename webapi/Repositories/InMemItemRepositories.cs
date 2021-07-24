using System;
using System.Collections.Generic;
using Webapi.Entities;

namespace Webapi.Repositories
{
    public class InMemItemRepositories{
        private readonly List<Item> items = new(){
            new Item{Id = Guid.NewGuid(),Name = "Table", Price = 35 , CreatedDate = DateTimeOffset.UtcNow},
            new Item{Id = Guid.NewGuid(),Name = "Book", Price = 42 , CreatedDate = DateTimeOffset.UtcNow},
            new Item{Id = Guid.NewGuid(),Name = "Pencil", Price = 60 , CreatedDate = DateTimeOffset.UtcNow}
        };
    }
    
}