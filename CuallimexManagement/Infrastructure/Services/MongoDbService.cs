using CuallimexManagement.Infrastructure.Interfaces;
using MongoDB.Driver;

namespace CuallimexManagement.Infrastructure.Services
{
    public class MongoDbService : IMongoDb
    {
        private readonly IMongoClient _mongoClient;
        private readonly IMongoDatabase _database;

        public MongoDbService(IMongoClient mongoClient, string databaseName)
        {
            _mongoClient = mongoClient;
            _database = _mongoClient.GetDatabase(databaseName);
        }
        public IMongoCollection<T> GetCollection<T>(string collectionName)
        {
            return _database.GetCollection<T>(collectionName);
        }
    }
}
