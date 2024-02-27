using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace CuallimexManagement.Entities;
public class CountFolio
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    [BsonElement("Value")]
    public string Value { get; set; }

}