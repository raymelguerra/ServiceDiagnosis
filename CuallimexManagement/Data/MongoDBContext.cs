using CuallimexManagement.Entities;
using MongoDB.Driver;

namespace CuallimexManagement.Data
{
    public class MongoDBContext
    {
        private readonly IMongoDatabase _database = null;

        public MongoDBContext(string connectionString, string databaseName)
        {
            var client = new MongoClient(connectionString);
            if (client != null)
                _database = client.GetDatabase(databaseName);
        }

        public IMongoCollection<Company> Companies
        {
            get
            {
                return _database.GetCollection<Company>("Companies");
            }
        }  
        
        public IMongoCollection<Equipment> Equipments
        {
            get
            {
                return _database.GetCollection<Equipment>("Equipments");
            }
        }
    }
}
