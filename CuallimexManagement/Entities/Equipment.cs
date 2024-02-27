using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace CuallimexManagement.Entities;

public class Equipment
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    [BsonElement("Brand")]
    public string Brand { get; set; }

    [BsonElement("Model")]
    public string Model { get; set; }

    [BsonElement("Serial")]
    public string SerialNumber { get; set; }

    [BsonElement("ManufactureYear")]
    public int ManufactureYear { get; set; }

}