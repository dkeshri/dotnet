using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapi.Data;
using Webapi.Entities;

namespace Webapi.Repositories
{
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

        public async Task DeleteItemAsync(Guid id)
        {
            await Task.Run(() =>
            {
                DeleteItem(id);
            });
        }

        public Item GetItem(Guid id)
        {
            Item item = context.Items.Find(id);
            return item;
        }

        public async Task<Item> GetItemAsync(Guid id)
        {
            return await Task.Run(() =>
            {
                return GetItem(id);
            });
        }

        public IEnumerable<Item> GetItems()
        {
            var items = context.Items.ToList<Item>();
            return items;
        }

        public async Task<IEnumerable<Item>> GetItemsAsync()
        {
            return await Task.Run(() =>
            {
                return GetItems();
            });
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