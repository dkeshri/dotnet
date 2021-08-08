using System;
using System.Collections.Generic;
using System.Linq;
using Webapi.Entities;

namespace Webapi.Repositories
{

    public class InMemItemRepositories : IItemsRepository
    {
        private readonly List<Item> items = new()
        {
            new Item { Id = Guid.NewGuid(), Name = "Table", Price = 35, CreatedDate = DateTimeOffset.UtcNow },
            new Item { Id = Guid.NewGuid(), Name = "Book", Price = 42, CreatedDate = DateTimeOffset.UtcNow },
            new Item { Id = Guid.NewGuid(), Name = "Pencil", Price = 60, CreatedDate = DateTimeOffset.UtcNow }
        };
        public IEnumerable<Item> GetItems()
        {
            return items;
        }
        public Item GetItem(Guid id)
        {
            return items.Where(item => item.Id == id).SingleOrDefault();
        }

        public void CreateItem(Item item)
        {
            if (item is not null)
                items.Add(item);
        }

        public void UpdateItem(Item item)
        {
            if (item is not null)
            {
                var index = items.FindIndex(existingItem => existingItem.Id == item.Id);
                items[index] = item;
            }
        }

        public void DeleteItem(Guid id)
        {

            var index = items.FindIndex(existingItem => existingItem.Id == id);
            items.RemoveAt(index);
        }
    }

}