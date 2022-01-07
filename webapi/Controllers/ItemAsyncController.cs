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
        public async Task<ActionResult<ItemDto>> GetItem(Guid id)
        {
            var item = await repository.GetItemAsync(id);
            if (item is null)
            {
                return NotFound();
            }
            return item.AsDto();
        }
        // Post /items
        [HttpPost]
        public async Task< ActionResult<ItemDto>> CreateItem(CreateItemDto itemDto)
        {
            Item item = new()
            {
                Id = Guid.NewGuid(),
                Name = itemDto.Name,
                Price = itemDto.Price,
                CreatedDate = DateTimeOffset.UtcNow
            };
             await repository.CreateItemAsync(item);
            return CreatedAtAction(nameof(GetItem), new { id = item.Id }, item.AsDto());
        }

        // put /items/{id}
        [HttpPut("{id}")]
        public async Task< ActionResult> UpdateItem(Guid id, UpdateItemDto updateItemDto)
        {
            var existingItem = await repository.GetItemAsync(id);
            if (existingItem is null)
            {
                return NotFound();
            }
            var updatedItem = existingItem with
            {
                Name = updateItemDto.Name,
                Price = updateItemDto.Price
            };
            await repository.UpdateItemAsync(updatedItem);
            return NoContent();

        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteItem(Guid id)
        {
            var existingItem = await repository.GetItemAsync(id);
            if (existingItem is null)
            {
                return NotFound();
            }
            await repository.DeleteItemAsync(id);
            return NoContent();
        }

    }

}