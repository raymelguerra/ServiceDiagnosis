using CuallimexManagement.Entities;
using CuallimexManagement.Infrastructure.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CuallimexManagement.Infrastructure.Services
{
    public class ReportService : IReport
    {
        private readonly IMongoDb _mongoService;
        private readonly IMongoCollection<Report> _collection;
        public ReportService(IMongoDb mongoService)
        {
            _mongoService = mongoService;
            _collection = _mongoService.GetCollection<Report>(typeof(Report).Name);
        }
        public async Task<Report> CreateAsync(Report report)
        {
            report.Folio = await GenerateConsecutiveNumber();
            await _collection.InsertOneAsync(report);
            return report;
        }

        public async Task<string> GenerateConsecutiveNumber()
        {
            // Encuentra el último registro para obtener el último número consecutivo
            var lastReport = await _collection.Find(new BsonDocument())
                .Sort(Builders<Report>.Sort.Descending("Folio"))
                .Limit(1)
                .FirstOrDefaultAsync();

            string lastNumber = "000000";

            if (lastReport != null)
            {
                lastNumber = lastReport.Folio;
            }

            int newNumber = int.Parse(lastNumber) + 1;

            // Formatea el nuevo número a un string de 6 dígitos
            string newFolio = newNumber.ToString("D6");

            return newFolio;
        }

        public async Task<DeleteResult> DeleteAsync(string Id)
        {
            var objId = new ObjectId(Id);
            var filter = Builders<Report>.Filter.Eq("_id", objId);
            return await _collection.DeleteOneAsync(filter);
        }

        public async Task<ICollection<Report>> GetAllAsync()
        {
            return await _collection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task<Report> GetByIdAsync(string Id)
        {
            var objId = new ObjectId(Id);
            var filter = Builders<Report>.Filter.Eq("_id", objId);
            return await _collection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<UpdateResult> UpdateAsync(string Id, Report report)
        {
            var objId = new ObjectId(Id);
            var filter = Builders<Report>.Filter.Eq("_id", objId);
            var updateDef = report.ToUpdateDefinition();
            return await _collection.UpdateOneAsync(filter, updateDef);
        }
    }
}
