using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapi.Data;
using Webapi.Entities;

namespace Webapi.Repositories{
    public class OracleEFRepository : IItemsRepository
    {
        private AppOracleDbContext context;
        public OracleEFRepository(AppOracleDbContext context)
        {
            this.context = context;
        }
        public void CreateItem(Item item)
        {
            context.Items.Add(item);
            context.SaveChanges();
        }

        public Task CreateItemAsync(Item item)
        {
            throw new NotImplementedException();
        }

        public void DeleteItem(Guid id)
        {
            Item item = context.Items.Find(id);
            
            context.Items.Remove(item);


            context.SaveChanges();
        }

        public Task DeleteItemAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Item GetItem(Guid id)
        {
            Item item = context.Items.Find(id);
            return item;
        }

        public Task<Item> GetItemAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Item> GetItems()
        {
            var items = context.Items.ToList<Item>();
            return items;
        }

        public Task<IEnumerable<Item>> GetItemsAsync()
        {
            throw new NotImplementedException();
        }

        public void UpdateItem(Item item)
        {
            throw new NotImplementedException();
        }

        public Task UpdateItemAsync(Item item)
        {
            throw new NotImplementedException();
        }
    }
}