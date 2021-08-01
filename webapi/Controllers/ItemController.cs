using Microsoft.AspNetCore.Mvc;
using Webapi.Repositories;
using System.Collections.Generic;
using Webapi.Entities;
using System;
using System.Linq;
using Webapi.Dtos;

namespace Webapi.Controllers
{
    // Get /Items
    [ApiController]
    [Route("items")]
    public class ItemsControllers : ControllerBase
    {
        private readonly IItemsRepository repository;
        public ItemsControllers(IItemsRepository repository)
        {
            this.repository = repository;
        }

        // Get /items
        [HttpGet]
        public IEnumerable<ItemDto> GetItems()
        {
            var items = repository.GetItems().Select(item => item.AsDto());
            return items;
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

    }

}