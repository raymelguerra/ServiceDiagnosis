using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace CuallimexManagement.Entities;
public class Responsible
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    [BsonElement("Name")]
    public string Name { get; set; }

}