using System;
using System.Collections.Generic;
using MongoDB.Driver;
using Webapi.Entities;

namespace Webapi.Repositories
{
    public class MongoDbItemsRepository : IItemsRepository
    {
        private const string DATEBASE_NAME = "WebApi";
        private const string COLLECTION_NAME = "items";
        private readonly IMongoCollection<Item> itemsCollection;
        public MongoDbItemsRepository(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(DATEBASE_NAME);
            itemsCollection = database.GetCollection<Item>(COLLECTION_NAME);

        }
        public void CreateItem(Item item)
        {
            itemsCollection.InsertOne(item);
        }

        public void DeleteItem(Guid id)
        {
            throw new NotImplementedException();
        }

        public Item GetItem(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Item> GetItems()
        {
            throw new NotImplementedException();
        }

        public void UpdateItem(Item item)
        {
            throw new NotImplementedException();
        }
    }
}