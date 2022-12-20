using System;
using System.Collections.Generic;
using Catalog.Entities;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Catalog.Repositories
{
    public class MongoDbItemRepository : IItemRepository
    {
        private const string databaseName = "catalog";
        private const string collectionName = "items";
        private readonly FilterDefinitionBuilder<Item> filterBuilder = Builders<Item>.Filter;
        public IMongoCollection<Item> itemsCollection { get; set; }
        public MongoDbItemRepository(IMongoClient mongoClient)
        {
            var mongoDatabase = mongoClient.GetDatabase(databaseName);
            itemsCollection = mongoDatabase.GetCollection<Item>(collectionName);
        }
        public void CreateItem(Item item)
        {
            itemsCollection.InsertOne(item);
        }

        public void DeleteItem(Item item)
        {
           var filter = filterBuilder.Eq(existingItem => existingItem.Id, item.Id);
           itemsCollection.DeleteOne(filter);
        }

        public Item GetItem(Guid id)
        {
            var filter = filterBuilder.Eq(item => item.Id, id);
            return itemsCollection.Find(filter).SingleOrDefault();
        }

        public IEnumerable<Item> GetItems()
        {
            return itemsCollection.Find(new BsonDocument()).ToList();
        }

        public void UpdateItem(Item item)
        {
            var filter = filterBuilder.Eq(existingItem => existingItem.Id, item.Id);
            itemsCollection.ReplaceOne(filter, item);
        }
    }
}