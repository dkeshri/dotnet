using Microsoft.AspNetCore.Mvc;
using Webapi.Repositories;
using System.Collections.Generic;
using Webapi.Entities;
using System;
using System.Linq;
using Webapi.Dtos;
using System.Threading.Tasks;

namespace Webapi.Controllers
{
    // Get /Items
    [ApiController]
    [Route("itemsAsync")]
    public class ItemsAsyncControllers : ControllerBase
    {
        private readonly IItemsRepository repository;
        public ItemsAsyncControllers(IItemsRepository repository)
        {
            this.repository = repository;
        }

        // Get /items
        [HttpGet]
        public async Task<IEnumerable<ItemDto>> GetItems()
        {
            
            var items = await repository.GetItemsAsync();
            return items.Select(item => item.AsDto());
        }
        // Get /items/{id}
        [HttpGet("{id}")]
        public ActionResult<ItemDto> GetItem(Guid id)
        {
            var item = repository.GetItem(id);
            if (item is null)
            {
                return NotFound();
            }
            return item.AsDto();
        }
        // Post /items
        [HttpPost]
        public ActionResult<ItemDto> CreateItem(CreateItemDto itemDto)
        {
            Item item = new()
            {
                Id = Guid.NewGuid(),
                Name = itemDto.Name,
                Price = itemDto.Price,
                CreatedDate = DateTimeOffset.UtcNow
            };
            repository.CreateItem(item);
            return CreatedAtAction(nameof(GetItem), new { id = item.Id }, item.AsDto());
        }

        // put /items/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateItem(Guid id, UpdateItemDto updateItemDto)
        {
            var existingItem = repository.GetItem(id);
            if (existingItem is null)
            {
                return NotFound();
            }
            var updatedItem = existingItem with
            {
                Name = updateItemDto.Name,
                Price = updateItemDto.Price
            };
            repository.UpdateItem(updatedItem);
            return NoContent();

        }
        [HttpDelete("{id}")]
        public ActionResult DeleteItem(Guid id)
        {
            var existingItem = repository.GetItem(id);
            if (existingItem is null)
            {
                return NotFound();
            }
            repository.DeleteItem(id);
            return NoContent();
        }

    }

}