using System;
using System.Collections.Generic;
using Webapi.Entities;

namespace Webapi.Repositories
{
    public interface IItemsRepository
    {
        Item GetItem(Guid id);
        IEnumerable<Item> GetItems();
    }

}