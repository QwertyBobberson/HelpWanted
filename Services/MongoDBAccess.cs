using MongoDB;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Collections;
using MongoDB.Bson;
using System;
namespace HelpWanted.Services
{
    public class MongoDBAccess
    {
        IMongoDatabase db;

        public static string databaseName = "Projects";
        public static string collectionName = "Projects";

        public MongoDBAccess(string database)
        {
            MongoClient client = new MongoClient();
            db = client.GetDatabase(database);
        }

        public void AddItem<T>(string table, T item)
        {
            var collection = db.GetCollection<T>(table);
            collection.InsertOne(item);
        }

        public List<T> GetItems<T>(string table)
        {
            var collection = db.GetCollection<T>(table);
            return collection.Find(new BsonDocument()).ToList();
        }

        public void EditItem<T>(string table, BsonBinaryData id, T item)
        {
            var collection = db.GetCollection<T>(table);
            collection.ReplaceOne(
                new BsonDocument("_id", id),
                item,
                new ReplaceOptions{IsUpsert = false}
            );
        }

        public void RemoveItem<T>(string table, BsonBinaryData id)
        {
            var collection = db.GetCollection<T>(table);
            var filter = Builders<T>.Filter.Eq("_id", id);
            collection.DeleteOne(filter);
        }
    }
}