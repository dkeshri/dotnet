using Microsoft.AspNetCore.Mvc;
using Webapi.Repositories;
using System.Collections.Generic;
using Webapi.Entities;
using System;

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
        public IEnumerable<Item> GetItems()
        {
            var items = repository.GetItems();
            return items;
        }
        // Get /items/{id}
        [HttpGet("{id}")]
        public ActionResult<Item> GetItem(Guid id){
            var item = repository.GetItem(id);
            if(item is null){
                return NotFound();
            }
            return item;
        }

    }

}