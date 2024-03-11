using MongoDB.Driver;

namespace CuallimexManagement.Infrastructure.Interfaces;

public interface IMongoDb
{
    IMongoCollection<T> GetCollection<T>(string collectionName);
}
