using MongoDB;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Collections;
using MongoDB.Bson;

namespace HelpWanted.Services
{
    public class MongoDBAccess
    {
        IMongoDatabase db;

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
    }
}